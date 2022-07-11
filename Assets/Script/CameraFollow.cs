using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target; // 카메라가 따라가야 할 타겟
    public Vector3 offset;
    
    void Update()
    {
        transform.position = target.position + offset;
    }
}
