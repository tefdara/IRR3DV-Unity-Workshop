using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public GameObject VisualisationParent;
    Animator Animator;

    private void Start()
    {
        VisualisationParent.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "FPS Controller")
        //{
        //    VisualisationParent.gameObject.SetActive(true);
        //}

        Animator.enabled = true;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    VisualisationParent.gameObject.SetActive(false);
    //}

}
