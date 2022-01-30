using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerController : MonoBehaviour 
{

    private float speed = 25.0f;
    private float turnSpeed = 40.0f;
    private float horizontalInput;
    private float forwardInput;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        moveForward(speed, forwardInput);
        turn(turnSpeed, horizontalInput);
    }

    private void moveForward(float s, float verInput)
    {
        forwardInput = Input.GetAxis("Vertical");
        //transform.Translate(0, 0, 1);
        this.transform.Translate(Vector3.forward * Time.deltaTime * s * verInput);


    }

    private void turn(float s, float horInput)
    {
        horizontalInput = Input.GetAxis("Horizontal");

      //this.transform.Translate(Vector3.right * Time.deltaTime * s * horInput);
        this.transform.Rotate(Vector3.up, Time.deltaTime * s * horInput);
        
    }

}
