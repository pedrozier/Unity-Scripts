using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public GameObject[] enemies;
    private float spawnRangeX = 20;
    private float spawPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    

    void Start()
    {
        InvokeRepeating("spawnRandom", startDelay, spawnInterval);
    }

    
    void Update()
    {
        spawnRandom();
    }

    private void spawnTest()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int enemieIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawPosZ);

            Instantiate(enemies[enemieIndex], spawnPos, enemies[enemieIndex].transform.rotation);
        }
    }

    private void spawnRandom()
    {


        int enemieIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawPosZ);

        Instantiate(enemies[enemieIndex], spawnPos, enemies[enemieIndex].transform.rotation);
    }

}
