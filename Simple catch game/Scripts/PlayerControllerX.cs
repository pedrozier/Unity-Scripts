using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private int maxDogs = 3;
    private int minDogs = 0;
    public int numDogs;
    public int timeElapse;

    // Update is called once per frame
    void Update()
    {

        if (numDogs != 0)
        {
            timeElapse++;
        }

        if (timeElapse >= 80)
        {
            timeElapse = 0;
            numDogs--;
        }

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && numDogs != maxDogs)
        {
            numDogs++;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }

        

    }
}
