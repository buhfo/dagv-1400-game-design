using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 20;
    public GameObject projectilePrefab;
    
    void Update()
    {

        // Launches a bone when pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        // is the left boundary
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // is the right boundary
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // gets the players input
        horizontalInput = Input.GetAxis("Horizontal");
        // moves the player
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
