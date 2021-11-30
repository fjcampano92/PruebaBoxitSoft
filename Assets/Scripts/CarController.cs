using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnSpeed = 2.0f;
    private Rigidbody rb;
    public float gravityMultiplier = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0,Vector3.forward.z) * speed * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(-(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * speed * 10) / 2);
        }
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        localVelocity.x = 0;
        rb.velocity = transform.TransformDirection(localVelocity);
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * turnSpeed * 10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(-Vector3.up * turnSpeed * 10);
        }
    }

    void Fall()
    {
        rb.AddForce(Vector3.down * gravityMultiplier * 10);
    }

    private void FixedUpdate()
    {
        Movement();
        Turn();
        Fall();
    }
}
