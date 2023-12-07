using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cantGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "canGrab")
        {
            other.GetComponent<Grabbable>().cantGrab = true; 
        }
    }
}
