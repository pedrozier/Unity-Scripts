using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        rotate();
    }

    private void rotate()
    {
        float horIn = Input.GetAxis("Horizontal");

        float speed = 5f;

        transform.Rotate(Vector3.up * horIn * Time.deltaTime * speed, 1);
    }
}
