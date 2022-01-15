using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class guns : MonoBehaviour
{

    public int lootammo; 
    public float firerange;
    public GameObject impactfire;
    public ParticleSystem secwepfx;
    public float secwepammo;
    public bool primarywep = true;
    public bool secwep = false;
    public AudioSource fire;
    public bool reload;
    public int ammo = 30;
    public ParticleSystem flash;
    public ParticleSystem bullet;
    public ParticleSystem smoke;
    public float damage;
    public float range;
    public float firerate;
    public float esperafirerate;
    public GameObject impact;
    public Camera cam;
    public bool hold = false;
    // Use this for initialization
    void Start()
    {
        fire = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0 && primarywep == true)
        {
            hold = true;


        }
        if (Input.GetButtonUp("Fire1") && primarywep == true)
        {
            hold = false;

        }




        if (hold == true)
        {
            esperafirerate += 1;

        }
        if (esperafirerate > firerate)
        {
            Shoot();
        }
        if (Input.GetKeyDown("r") && ammo < 30 && primarywep == true && lootammo != 0)
        {
            hold = false;
            reload = true;


        }
        else
        {
            reload = false;

        }

        if (ammo == 0 && primarywep == true)
        {
            hold = false;
        }

        if (reload == true && lootammo + ammo >= 30)
        {
            lootammo += ammo - 30;
            ammo = 30;


        }

        if ((reload == true) && ((lootammo + ammo) < 30))
        {
            ammo = (lootammo + ammo);
            lootammo = 0;
        }

        if (Input.GetButtonDown("Fire1") && secwep == true && secwepammo > 0)
        {
            hold = true;
        }
        if (Input.GetButtonUp("Fire1") && secwep == true)
        {
            hold = false;
        }

        if (Input.GetKeyDown("2"))
        {
            secwep = true;
            primarywep = false;
        }
        if (Input.GetKeyDown("1"))
        {
            secwep = false;
            primarywep = true;
        }
        if (secwepammo == 0)
        {
            secwep = false;
            primarywep = true;
        }
    }


    void Shoot()
    {
        if (secwep == true && hold == true) {
            secwepfx.Play();
            secwepammo -= 1;
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, firerange))
                Debug.Log("mirando em:" + hit.transform.name);
            GameObject impactGO = Instantiate(impactfire, hit.point, Quaternion.LookRotation(hit.normal));
        }
        if (primarywep == true && hold == true)
        {
            fire.Play(1);
            ammo -= 1;
            esperafirerate = 0;
            bullet.Play();
            flash.Play();
            smoke.Play();
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))

                Debug.Log("mirando em:" + hit.transform.name);
            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}







