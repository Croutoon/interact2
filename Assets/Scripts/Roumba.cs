using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roumba : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;
    Rigidbody rb;
    bool driving = false;
    public Transform grabPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.L)){
            driving = true;
        }
        else
        {
            driving = false;
            if (Input.GetKey(KeyCode.L))
            {
                transform.Rotate(new Vector3(0, rotationSpeed, 0));
            }
            if (Input.GetKey(KeyCode.J))
            {
                transform.Rotate(new Vector3(0, -rotationSpeed, 0));
            }
        }
    }

    private void FixedUpdate()
    {
        if (driving)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Force);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "canGrab")
        {
            other.GetComponent<Grabbable>().grabbed = true;
            other.GetComponent<Grabbable>().grabPos = grabPoint;
        }
    }
}
