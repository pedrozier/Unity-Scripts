
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject powerUp;

    private float zEnemySpawn = 12f;
    private float xSpawnBound = 16f;
    private float zPowerUpRange = 5f;
    private float ySpawn = 0.75f;

    private float powerUpSpawnTime = 5f;
    private float enemySpawnTime = 1f;
    private float startDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerUp", startDelay, powerUpSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
            float randomX = Random.Range(-xSpawnBound, xSpawnBound);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].transform.rotation);


    }

    private void SpawnPowerUp()
    {
        float randomX = Random.Range(-xSpawnBound, xSpawnBound);
        float randomZ = Random.Range(-zPowerUpRange, zPowerUpRange);

        Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

        Instantiate(powerUp, spawnPos, powerUp.transform.rotation);
    }

}
