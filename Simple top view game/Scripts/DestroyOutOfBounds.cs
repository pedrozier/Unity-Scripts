using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBount = 30f;
    private float lowerBount = -10f;

    void Start()
    {

    }


    void Update()
    {
        if (transform.position.z > topBount)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBount)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }



}
