using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsPlayer : MonoBehaviour
{
    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical = Vector3.zero;

    float forwardSpeed = 5f;
    float  strafeSpeed = 5f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 2f;
    float timeToMaxHeight = 0.5f;

    void Start()
    {
        GetComponents();
        InitialCalculations();

    }

    void Update()
    {
        Jump();
        Moviment();
    }



    void InitialCalculations()
    {
        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;
    }

    void GetComponents()
    {
        controller = GetComponent<CharacterController>();
    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if(vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }
    }

    void Moviment()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        vertical += gravity * Time.deltaTime * Vector3.up;
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
