using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 5.0f;
    private float zBound = 3.0f;
    private float xBound = 10.0f;
    private float xBoundLeft = 6.0f;
    
    void Update()
    {
        MovePlayer();
        PlayerPosConstraints();
    }

    // moves the launch point for the fishing rod
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * -verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * -horizontalInput * Time.deltaTime);
    }

    // stops the launch point from going too far 
    void PlayerPosConstraints()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBoundLeft)
        {
            transform.position = new Vector3(xBoundLeft, transform.position.y, transform.position.z);
        }
    }



}
