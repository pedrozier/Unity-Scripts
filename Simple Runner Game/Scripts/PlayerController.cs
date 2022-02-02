using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private int force = 700;

    private float gravityModifier = 1.5f;

    private bool isOnGround = true;

    public bool gameOver;

    private Rigidbody playerRB;

    private Animator playerAnim;

    public ParticleSystem explosionParticle;

    public ParticleSystem dirtFx;

    public AudioClip jumpSound;

    public AudioClip crashSound;

    public AudioSource playerAudio;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        playerAnim = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;

    }

    
    void Update()
    {
        jump(force);

        if (gameOver)
        {
            dirtFx.Stop();
        }
    }

    private void jump(int f)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * f, ForceMode.Impulse);

            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");

            dirtFx.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

            dirtFx.Play();

        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();

            playerAudio.PlayOneShot(crashSound, 1.0f);

            

        }
        
        

        
    }

}
