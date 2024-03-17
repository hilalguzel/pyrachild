using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController PlayerController;

    public float speed = 15f;
    [SerializeField] private  float gravity = 9.18f;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGround;
    void Update()
    {
        isGround = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0 )
        {
            velocity.y = -2f;
        }
        
        if(Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        PlayerController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        PlayerController.Move(velocity * Time.deltaTime); // DH = 1/2*g*Time^2 freeFall pyhsics
    }
}
