using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float speed = 10f;
    private float xRange = 20f;

    public GameObject projectile;

    void Start()
    {
        
    }

    
    void Update()
    {
        playerMove(speed);
        shoot(projectile);
    }

    private void playerMove(float s)
    {
        if (this.transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (this.transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        transform.Translate(Vector3.right * Time.deltaTime * getHorInput() * s);
    }

    private float getHorInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        return horizontalInput;
    }

    void shoot(GameObject projectile)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile,transform.position, projectile.transform.rotation);
        }
    }

}
