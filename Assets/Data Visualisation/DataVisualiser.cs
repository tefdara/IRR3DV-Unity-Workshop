//Introduction to Real-time Rendering and 3D Visualisation in Unity - 2021

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DataVisualiser : MonoBehaviour
{
    public DataStream DataStream;

    public ParticleSystem Ps;
    public float VisualisationRadius = 5f;

    //Awake is a Unity internal method and is called once when the game object is created in the scene
    private void Awake()
    {
        /* Here we are going to check whether the particle system variable has been assigned in the editor or not 
        and if not we will find it using GetComponent method that unity provides */
        if (Ps == null)
            Ps = GetComponent<ParticleSystem>();
    }


    //OnEnable is a Unity internal method and is called every time the game object is enabled

    private void OnEnable()
    {
        //We subscribe to the data streamer event and listen to any changes in the data.
        DataStream.EarthquakeUpdated += SetPoints;
    }

    // The SetPoints method will be called every time the DataStreamer updates the data and publishes the event
    private void SetPoints(Earthquakes data)
    {
        //loop through all the features of the received earthquake data
        for (int i = 0; i < data.features.Length; i++)
        {
            // get the latitude and longitude 
            float lon = data.features[i].geometry.coordinates[0];
            float lat = data.features[i].geometry.coordinates[1];

            //set the range for elevation to [0, PI] 
            float theta = (Mathf.Deg2Rad * lat) + (Mathf.PI * 0.5f);
            
            //set tje range for azimuth to [0, 2PI]
            float phi = (Mathf.Deg2Rad * lon) + Mathf.PI;

            //Cartesian coordinates
            float x = VisualisationRadius * Mathf.Sin(theta) * Mathf.Cos(phi);
            float y = VisualisationRadius * Mathf.Sin(theta) * Mathf.Sin(phi);
            float z = VisualisationRadius * Mathf.Cos(theta);

            //resulting position as a vector
            Vector3 pos = new Vector3(x,y,z);

            //Emitting a single particle at each position 
            Ps.Emit(new ParticleSystem.EmitParams { position = pos}, 1);
    
        }

    }
}
