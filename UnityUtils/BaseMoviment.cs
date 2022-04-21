using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoviment : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction = Vector3.zero;
    Vector3 currentVelocity;

    float acceleration = 100;
    float maxSpeed = 10;


    void Start()
    {
        
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref currentVelocity, maxSpeed / acceleration);

        this.transform.position += velocity * Time.deltaTime;
    }

}
