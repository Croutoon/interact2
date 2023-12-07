using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraScript : MonoBehaviour
{

    public Transform target;
    public float rotationSpeed = 1.0f;
    public float focusSpeed = 1.0f;
    public float targetPosDivide = 2;

    public Volume volume;
    private DepthOfField df;

    Vector3 startPos;
    void Start()
    {
        volume.profile.TryGet(out df);
        startPos = transform.position;
    }
    void FixedUpdate()
    {

        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed);
        df.focusDistance.value = Mathf.Lerp(df.focusDistance.value, Vector3.Distance(transform.position, target.position), focusSpeed);

        Vector3 targetPos = startPos + new Vector3(target.position.x, 0f, target.position.z) / targetPosDivide;
        transform.position = Vector3.Lerp(transform.position, targetPos, rotationSpeed);

    }
}
