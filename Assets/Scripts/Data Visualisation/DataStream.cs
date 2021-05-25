//Introduction to Real-time Rendering and 3D Visualisation in Unity - 2021

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[System.Serializable]
public class DataStream : MonoBehaviour
{
    // URL pointing to the feed. It has to be JSON for this script to work.
    public string URL  = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/significant_month.geojson";

    /*This is the event that will be published when we retrieve  and parse the data 
      whoever is listening for that event - in our case the DataVisualiser class - will be notified and will get the parsed data as an earthquakes object */
    public event Action<Earthquakes> EarthquakeUpdated;


    //The API call time interval in seconds. It is defaulted to 60 since the earthquakes data is updated every minute
    public int DataFetchInterval = 60;

    //Unity internal method called once when the script is started
    private void Start()
    {
        /*Here we start the API calls using a coroutine 
          coroutines are a way to make things happen at certain defined points in time */
         StartCoroutine(StartAPICallRoutine());
    }


    //This coroutine will call the API routine below every n seconds defined by the user; It is basically a loop 
    private IEnumerator StartAPICallRoutine()
    {
        //this a coroutine way of create a an infinite loop 
        while (true)
        {
            // Start the API call 
            yield return APICallRoutine();
            // Wait however many seconds defined by the user - 60 in this case.
            yield return new WaitForSeconds(DataFetchInterval);
            //...
            //after the wait go to the top and do it again
        }

    }

    
    //This is the main coroutine where we ask for the data and retrive it
    private IEnumerator APICallRoutine()
    {
        // A block that will request the data and wait for its return
        using (UnityWebRequest request = UnityWebRequest.Get(URL))
        {
            // wait until you get a response 
            yield return request.SendWebRequest();
            
            // if there is an error, log it to the console 
            if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.LogError(request.error);
            }

            // otherwise 
            else
            {
                //encode the data to UTF8 just in case it is not properly formated. This is needed to Json 
                string result = System.Text.Encoding.UTF8.GetString(request.downloadHandler.data);

                //convert the Json object to a c# object  
                Earthquakes data = JsonUtility.FromJson<Earthquakes>(result);

                //publish the event and the data to whoever is listening 
                EarthquakeUpdated?.Invoke(data);
            }
        }

    }


}
