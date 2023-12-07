using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalvageBin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "canGrab")
        {
            Destroy(other.gameObject);
        }
    }
}
