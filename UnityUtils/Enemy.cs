using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float life;
    public float armor;
    public float resistence;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            float damage = (projectile.damage - ((armor * 2) + (resistence/2)));
            Debug.Log(damage);
            if(damage >= 0) 
            {
                life = life - damage;
            }
            
        }
    }
   
}
