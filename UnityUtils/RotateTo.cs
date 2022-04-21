using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        RotateToTarget(target);
    }

    public void RotateToTarget(GameObject target)
    {
        Vector3 relativePos = target.transform.position - this.transform.position;
        this.gameObject.transform.rotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up),rotationSpeed);
    }

}
