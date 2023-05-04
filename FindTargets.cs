using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The GameObject needs a SphereCollider with isTrigger active (to use as range)
//All the targets(GameObject) need to be tagged as the same as the variable `targetTag` otherwise it won't work
//You can use this Class as base model by overriding the `Fire()` method, to make the turrets of your game for example


public class FindTargets : MonoBehaviour
{

#region Variables

    public string targetTag = "";

    public float range;

    public float fireRate = 1f;
    private bool canFire = true;

    private List<GameObject> targets = new List<GameObject>();

#endregion Variables

#region UnityMethods
    void Start()
    {
        range = GetComponent<SphereCollider>().radius;
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            targets.Add(other.gameObject);
            if (canFire)
            {
                StartCoroutine(FireCoroutine());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (targets.Contains(other.gameObject))
        {
            targets.Remove(other.gameObject);
        }
    }

#endregion UnityMethods

#region CustomMethods

    private IEnumerator FireCoroutine()
    {
        canFire = false;
        while (targets.Count > 0)
        {
            Fire();
            yield return new WaitForSeconds(fireRate);
        }
        canFire = true;
    }

    public virtual void Fire()
    {
        Debug.Log("shot at " + getNearstTarget());
        //TODO enable FX, deal damage/destroy enemy...
    }

    /// <summary>
    /// Get the closer <b>target</b> inside the <b>targets List</b>
    /// </summary>
    /// <returns>returns the <b>GameObject</b> of the <b>target</b></returns>
    public GameObject getNearstTarget()
    {
        GameObject finalTarget = null;
        foreach(GameObject target in targets)
        {
            if(finalTarget == null)
            {
                finalTarget = target;
            }
            if(Vector3.Distance(this.transform.position, target.transform.position) < Vector3.Distance(this.transform.position, finalTarget.transform.position))
            {
                finalTarget = target;
            }
        }
        return finalTarget;
    }

#endregion CustomMethods

}
