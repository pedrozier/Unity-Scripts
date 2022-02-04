using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3.0f;

    private Rigidbody enemyRB;

    private GameObject player;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
        fallow();

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }

    private void fallow()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRB.AddForce(lookDirection * speed);
    }

}
