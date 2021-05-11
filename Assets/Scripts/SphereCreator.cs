using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCreator : MonoBehaviour
{
    public GameObject Sphere;


    public void MakeSphere() 
    {

        Instantiate(Sphere, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f), Quaternion.identity);
    }
}
