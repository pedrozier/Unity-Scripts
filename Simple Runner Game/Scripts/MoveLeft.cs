using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    private float speed = 30f;
    private float destroyPos = 10;

    private PlayerController playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x <= -destroyPos && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

    }
}
