using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PovCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.5f;
    public Vector3 offSet;

    void LateUpdate()
    {
        Vector3 neededPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, neededPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
