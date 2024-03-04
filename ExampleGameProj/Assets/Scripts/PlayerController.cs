using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // sets the character controller, and gives physics attributes//
    [SerializeField] private CharacterController controller;
    private float moveSpeed;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float crawlSpeed = 2.5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.81f;

    // sets the ground check and its attributes//
    [SerializeField] public Transform groundCheck;
    [SerializeField] public float groundDistance = 0.4f;
    [SerializeField] public LayerMask groundMask;
    [SerializeField] public Transform headCheck;
    [SerializeField] public float headDistance = 0.4f;

    // sets velocity as a number with 3 variables //
    Vector3 velocity;

    // makes sure the floor is being touched //
    bool isGrounded;
    bool isUnder;
    bool isCrouching;
    bool isRunning;

    private void Start()
    {
        //this makes sure the player is in the proper state upon loading in.
        isCrouching = false;
        moveSpeed = walkSpeed;
        isRunning = false;
    }
    void Update()
    {
        // this checks if you are on the ground, or underneath something //
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isUnder = Physics.CheckSphere(headCheck.position, headDistance, groundMask);

        // sticks players to the ground when //
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // this toggles crouching, and changes the player height and speed based off of that. it also restricts jumping and running while crouched.
        if (Input.GetButtonDown("Crouch"))
        {   
            //stops the player from getting their head stuck in something
            if (isUnder && isCrouching)
            {
                print("cant get up dawg");
            }
            else
            {
                isCrouching = !isCrouching;
            }

        }

        // makes sure the player is in the crouching state, changes their size and speed //
        if(isCrouching)
        {
            isRunning = false;
            moveSpeed = crawlSpeed;
            transform.localScale = new Vector3(1, 0.5f, 1);
        }

        // makes sure the player is the correct size when not crouching //
        if (!isCrouching)
        {
            transform.localScale = new Vector3(1,1,1);

            // if the player isnt running, switches movement speed to walk speed //
            if(!isRunning)
            {
                moveSpeed = walkSpeed;
            }
        }

        // this toggles running
        // if youre under something you cant run, otherwise you can
        if (Input.GetButtonDown("Sprint"))
        {
            // stops players from clipping into things
            if (isUnder && isCrouching)
            {
                print("cant get up dawg");
            }
            else
            {
                isRunning = !isRunning;
            }
        }
        //sets speed to walk speed when you arent crouching or running
        if(!isRunning && !isCrouching)
        {
            moveSpeed = walkSpeed;
        }
        // makes you go faster, also stops the crouching state
        if(isRunning)
        {
            isCrouching = false;
            moveSpeed = runSpeed;
        }

        //this is movement on the ground//
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * moveSpeed * Time.deltaTime);

        // this is to jump, if player is on the ground and not under something //
        if (Input.GetButtonDown("Jump") && isGrounded && !isCrouching && !isUnder) 
        {
            velocity.y = Mathf.Sqrt(jumpForce * 2f * gravity);
        }

        // if the player hits their head while jumping, this stops the players movement and makes them fall quicker //
        if(!isGrounded && isUnder)
        {
            velocity.y = -1f;
            velocity.y -= gravity * Time.deltaTime;
        }

        // this makes sure the gravity and movement is proportional to the time instead of framerate//
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
