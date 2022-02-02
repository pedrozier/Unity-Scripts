using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstacle;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    public float spawnTime = 3;
    private float startDelay = 2;

    private PlayerController playerControlerScript;

    void Start()
    {
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("spawnObj",startDelay, spawnTime);
    }

    public void spawnObj()
    {
        if (playerControlerScript.gameOver == false)
        {

            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);

        }

    }

}
