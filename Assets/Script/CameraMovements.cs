using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        // Calculate the initial offset
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) { 
        transform.position = target.position + offset;
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
    }
}