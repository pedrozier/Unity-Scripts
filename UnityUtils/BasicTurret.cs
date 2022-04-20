using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTurret : MonoBehaviour
{
    
    private GameObject target;
    private GameObject[] targets;
    public GameObject projectile;

    public GameObject shotpos1;
    public GameObject shotpos2;

    public float rotationSpeed;

    public float maxDistance;
    public float minDistance;

    public float attackSpeed;

    void Start()
    {

    }

    void Update()
    {
        //teste
        if (Input.anyKeyDown)
        {
            Shot();
        }
        //teste

        targets = FindAllTargetsOfTag("enemy");
        target = FindNearestTarget(targets);

        if (targets.Length != 0)
        {
            float distance = Vector3.Distance(this.transform.position, target.transform.position);
            if (distance > minDistance && distance < maxDistance)
            {
                RotateToTarget(target);
            }
        }
    }

    void RotateToTarget(GameObject target)
    {
        Vector3 relativePos = target.transform.position - this.transform.position;
        this.gameObject.transform.rotation = Quaternion.RotateTowards(this.gameObject.transform.rotation, Quaternion.LookRotation(relativePos, Vector3.up), rotationSpeed);
    }

    GameObject[] FindAllTargetsOfTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    GameObject FindNearestTarget(GameObject[] targets)
    {
        GameObject nearTarget = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = this.transform.position;
        foreach (GameObject target in targets)
        {
            float dist = Vector3.Distance(target.transform.position, currentPos);
            if (dist < minDist)
            {
                nearTarget = target;
                minDist = dist;
            }
        }
        return nearTarget;

    }

    void Shot()
    {
        Instantiate(projectile, shotpos1.transform.position,shotpos1.transform.rotation);
        Instantiate(projectile, shotpos2.transform.position, shotpos2.transform.rotation);
    }



}
