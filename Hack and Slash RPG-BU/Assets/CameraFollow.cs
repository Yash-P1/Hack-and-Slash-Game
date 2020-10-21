using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 CameraFollowPosition = Player.position;
        CameraFollowPosition.y = transform.position.y;
        transform.position = CameraFollowPosition;
    }
}
