using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f; 
    

    void Start()
    {
        
    }

    
    void Update()
    {
        forwardMove(speed);
    }

    private void forwardMove(float s)
    {
        this.transform.Translate(Vector3.forward * Time.deltaTime * s);
    }
}
