using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawnController : MonoBehaviour
{
    public GameObject playerPrefab;

    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;

    public float height;

    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), height, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }

}
