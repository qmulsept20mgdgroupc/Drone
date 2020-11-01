using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;


public class DroneMovement : MonoBehaviour
{
    public GameObject MainCamera;
    private Rigidbody rb;
    private float _speed = 0.2f;
    private float offset = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 newPosition = rb.position + new Vector3(h * _speed, 0f, v * _speed);
        newPosition.x = Mathf.Clamp(newPosition.x, -50f, 50f);
        newPosition.z = Mathf.Clamp(newPosition.z, -50f, 50f);
        rb.position = newPosition;

        if (Input.GetKey("space"))
        {
            Vector3 tempPos = transform.position;
             tempPos.y += offset;
            transform.position = tempPos;
        }

        rb.rotation = Quaternion.Euler(90f, 0f, h * _speed * -100f);
    }
}
 


