using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GrabScript : MonoBehaviour
{

    RaycastHit hit;

    [Header("Visuals:")]
    public Camera cam;
    public Transform robotBody;
    public float speed;

    [Header("Crain:")]
    public Transform rootArm;
    public Transform foreArm;
    public float rootOpen;
    public float rootClosed;
    public float foreOpen;
    public float foreClosed;
    public Transform grabPoint;



    GameObject[] objects;


    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("canGrab");
    }

    void Update()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            Vector3 targetPostition = new Vector3(hit.point.x, robotBody.position.y, hit.point.z);
            Vector3 dir = targetPostition - robotBody.position;

            robotBody.rotation = Quaternion.Slerp(robotBody.rotation, Quaternion.LookRotation(dir), Time.deltaTime * speed);
        }

        if(Input.GetMouseButtonUp(0))
        {
            for(int i = 0; i < objects.Length; i++)
            {
                if (objects[i] != null)
                {
                    objects[i].GetComponent<Grabbable>().grabbed = false;
                }
            }
        }

        RobotArm();
    }

    void RobotArm()
    {
        float targetRoot = rootClosed;
        float targetFore = foreClosed;

        if (Input.GetMouseButton(0))
        {
            targetRoot = rootOpen;
            targetFore = foreOpen;
        }

        rootArm.localRotation = Quaternion.Slerp(rootArm.localRotation, Quaternion.Euler(new Vector3(targetRoot, 0f, 90f)), .01f);
        foreArm.localRotation = Quaternion.Slerp(foreArm.localRotation, Quaternion.Euler(new Vector3(0f, targetFore, 0f)), .01f);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "canGrab")
        {
            Debug.Log("Finds Object");
            if(Input.GetMouseButton(0))
            {
                    other.GetComponent<Grabbable>().grabbed = true;
                    other.GetComponent<Grabbable>().grabPos = grabPoint;
            }
        }
    }
}
