using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform target;
    public float smoothFactor = 0.125f;

    public Vector3 offset;

    // LateUpdate is called after Update methods
    void LateUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothFactor);
        transform.position = smoothPos;
    }
}
