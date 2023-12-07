using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool grabbed = false;
    public bool cantGrab = false;
    public Transform grabPos;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(grabbed && !cantGrab)
        {
            Vector3 dir = grabPos.position - transform.position;
            rb.AddForce(dir * Vector3.Distance(grabPos.position, transform.position));
        }
    }
}
