using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform orientation;
    public Material rightTrack;
    public Material leftTrack;
    public float speed;
    public float rotationSpeed;
    float leftSpeed = 0;
    float rightSpeed = 0;
    Rigidbody rb;
    float h;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {

        h = Input.GetAxis("Vertical");


        leftSpeed = 0;
        rightSpeed = 0;

        if (Input.GetKey(KeyCode.D))
        {
            orientation.Rotate(new Vector3(0, rotationSpeed, 0));
            leftSpeed = -1;
            rightSpeed = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            orientation.Rotate(new Vector3(0, -rotationSpeed, 0));
            leftSpeed = 1;
            rightSpeed = -1;
        }

        if(h > 0)
        {
            leftSpeed = 1;
            rightSpeed = 1;
        }
        if (h < 0)
        {
            leftSpeed = -1;
            rightSpeed = -1;
        }

        SetTrackSpeed();
    }

    void FixedUpdate()
    {
        rb.AddForce(orientation.forward * speed * h, ForceMode.Force);
    }

    void SetTrackSpeed()
    {
        rightTrack.SetFloat("_Speed", rightSpeed);
        leftTrack.SetFloat("_Speed", leftSpeed);
    }
}
