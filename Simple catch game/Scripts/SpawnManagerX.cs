﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = 22;
    private float spawnLimitXRight = 10;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    public float spawnInterval = 4.0f;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void spawnRandomBall ()
    {

        spawnInterval = Random.RandomRange(3, 6);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(-spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        int randonNum = Random.RandomRange(0, ballPrefabs.Length);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randonNum], spawnPos, ballPrefabs[randonNum].transform.rotation);
    }

}
