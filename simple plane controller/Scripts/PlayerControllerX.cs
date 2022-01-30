using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 30f;
    private float rotationSpeed = 100f;
    private float horizontalInput;
    private float propSpeed = 500f;
    public GameObject prop;
    

    
    void Start()
    {

    }

    
    void Update()
    {
        forward(speed);
        turn(rotationSpeed);
        propAnim(propSpeed,prop);
        
    }

    private void forward(float s)
    {
        transform.Translate(Vector3.forward * s * Time.deltaTime);

    }

    private void turn(float s)
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.right * Time.deltaTime * s * horizontalInput);
    }

    private void propAnim(float s, GameObject p)
    {
        p.transform.Rotate(Vector3.back * s * Time.deltaTime);
    }
}
