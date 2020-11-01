using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public GameObject Drone;
    public float speed = 0.125f;
    public Vector3 offset;
    public float speedH = 1.0f;
    private float hor = 0.0f;
    public Transform cam;

    void Update()
    {
        hor += speedH * Input.GetAxis("Mouse X");
        hor = Mathf.Clamp(hor, -45f, 45f);
        transform.eulerAngles = new Vector3(30f, hor, 0.0f);
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
    }
    void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothedPosition;

    }
}