using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public GameObject character;
    public GameObject botton;
    public GameObject top;

    Camera mainCamera;

    Animator topAnimator;
    Animator bottonAnimator;

    Vector3 velocity;
    Vector3 direction = Vector3.zero;
    Vector3 currentVelocity;

    float acceleration = 100;
    float maxSpeed = 5;
    float horizontalInput;

    //ANIMATION SATATES//
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_RUN = "Player_Run";
    //=================//
    const int PLAYER_SCALE = 4;

    void Start()
    {
        topAnimator = top.GetComponent<Animator>();
        bottonAnimator = botton.GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Move(horizontalInput);
        SetLookDirection(horizontalInput);
    }

    void Move(float horizontalInput)
    {
        direction = new Vector3(horizontalInput, 0, 0).normalized;

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref currentVelocity, maxSpeed / acceleration);

        this.transform.position += velocity * Time.deltaTime;

        if(horizontalInput != 0)
        {
            AnimationRun();
        } else
        {
            AnimationIdle();
        }
    }

    void SetLookDirection(float horizontalInput)
    {
        if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-PLAYER_SCALE,PLAYER_SCALE,PLAYER_SCALE);
        } else if(horizontalInput > 0)
        {
            this.transform.localScale = new Vector3(PLAYER_SCALE, PLAYER_SCALE, PLAYER_SCALE);
        }
    }
    void AnimationRun()
    {
        bottonAnimator.Play(PLAYER_RUN);
        topAnimator.Play(PLAYER_RUN);
    }
    void AnimationIdle()
    {
        bottonAnimator.Play(PLAYER_IDLE);
        topAnimator.Play(PLAYER_IDLE);
    }
}
