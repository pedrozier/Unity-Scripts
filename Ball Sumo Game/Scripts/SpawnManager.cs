using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;

    public GameObject powerUp;

    private int enemyCount;

    private int waveNumber = 1;

    void Start()
    {
        spawnEnemyWave(3);        
    }


    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            spawnEnemyWave(waveNumber);
            waveNumber++;
        }
    }

    private void spawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            spawnEnemy();
            
        }
            spawnPower();
    }

    private void spawnEnemy()
    {
        Instantiate(enemyPrefab, generateRandomPos(), enemyPrefab.transform.rotation);
    }



    private Vector3 generateRandomPos()
    {
        float spawnRange = 9;

        float spawnPosX = Random.Range(-spawnRange, spawnRange);

        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    private void spawnPower()
    {
        Instantiate(powerUp, generateRandomPos(), powerUp.transform.rotation);
    }

}
