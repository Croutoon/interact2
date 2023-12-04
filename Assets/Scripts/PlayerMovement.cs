using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform orientation;
    public float speed;
    public float rotationSpeed;
    Rigidbody rb;
    float h;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        h = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.D))
        {
            orientation.Rotate(new Vector3(0, rotationSpeed, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            orientation.Rotate(new Vector3(0, -rotationSpeed, 0));
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(orientation.forward * speed * h, ForceMode.Force);
    }
}
