using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowPlayer : MonoBehaviour
{

    public GameObject cameraSlot;
    private Vector3 offset = new Vector3(0, 6, -9);

    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        fallowPlayer(cameraSlot);
    }

    private void fallowPlayer(GameObject c)
    {
        //this.transform.position = c.transform.position;
        this.transform.position = c.transform.position + offset;
    }

}
