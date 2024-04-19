using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    public float speed;
    private float xRange = 17;
    public Transform blaster;
    public GameObject laserBolt;

    void Update()
    {
        //set Horizontal Input to get values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");

        //moves player left and rught
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //keep player within bounds
        //Left Wall
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z );
        }
        //Right Wall
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // fires a laser on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // creates a laser at the position of the blaster with the rotation of the laser
            Instantiate(laserBolt, blaster.transform.position, laserBolt.transform.rotation);
        }
    }

    //deletes any object with a trigger that hits the player
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        Destroy(other.gameObject);
    }
}
