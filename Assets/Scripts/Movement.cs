using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private ParticleSystem flameParticle;

    public AudioSource jumpSound;

    public AudioSource flameSound;

    public CharacterController Control;

    [SerializeField] public float speed = 8f;
    public float gravity = -9.81f;

    [Header("Ground")]
    public Transform groundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;
    public float JumpHeigth = 0.5f;

    private void Start()
    {
        flameParticle.Stop();
        flameParticle.GetComponent<Collider>().enabled = false;
        flameSound.Stop();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, GroundDistance, groundMask);

        if(isGrounded && velocity.y <0 )
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Control.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        Control.Move(velocity * Time.deltaTime); // DH = 1/2.g.time^2

        if(Input.GetButtonDown("Jump") && isGrounded )
        {
            jumpSound.Play();
            velocity.y = Mathf.Sqrt(JumpHeigth * -2f * gravity);
        }
        if(Input.GetMouseButtonDown(0))
        {
            flameParticle.Play();
            flameParticle.GetComponent<Collider>().enabled = true;
            if (!PauseMenu.Instance.gameIsPaused)
            {
                flameSound.Play();
            }
           
        }
        if(Input.GetMouseButtonUp(0))
        {
            flameParticle.Stop();
            flameParticle.GetComponent<Collider>().enabled = false;
            flameSound.Stop();
        }
    }
}
