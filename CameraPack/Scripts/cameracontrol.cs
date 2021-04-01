using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{

    public float movimentSpeed;
    public float movimentTime;
    public float normalSpeed;
    public float fastSpeed;
    
    public Vector3 newPosition;

    
    void Start()
    {
        newPosition = transform.position;
        
    }

    
    void Update()
    {
        HandleMovimentInput();
    }


    void HandleMovimentInput()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            newPosition += (transform.forward * movimentSpeed);
        }

        if(Input.GetKey(KeyCode.S))  
        {
            newPosition += (transform.forward * -movimentSpeed);
        }

        if(Input.GetKey(KeyCode.D))  
        {
            newPosition += (transform.right * movimentSpeed);
        }

        if(Input.GetKey(KeyCode.A))  
        {
            newPosition += (transform.right * -movimentSpeed);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            movimentSpeed = fastSpeed;
        }
        else
        {
            movimentSpeed = normalSpeed;
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movimentTime);
    }



}
