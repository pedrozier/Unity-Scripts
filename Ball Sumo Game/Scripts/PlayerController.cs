using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 5f;

    private float powerStrength = 50;

    private bool hasPowerUp = false;

    private Rigidbody playerRB;

    private GameObject focusView;

    public GameObject powerupIndicator;

    private Vector3 offset = new Vector3(0, -0.5f, 0);



    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focusView = GameObject.Find("Focus View");
    }

    
    void Update()
    {
        move();

        powerupIndicator.transform.position = transform.position + offset;
    }

    private void move()
    {
        float VerIn = Input.GetAxis("Vertical");

        playerRB.AddForce(focusView.transform.forward  * speed * VerIn);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            powerupIndicator.gameObject.SetActive(true);

            Destroy(other.gameObject);

            hasPowerUp = true;
            
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);

        hasPowerUp = false;

        powerupIndicator.gameObject.SetActive(false);
    }
}
