using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 15;
    private float xRange = 17;
    private float waitTime = 5;

    private bool damageUp;

    private List<string> inventory = new List<string>();

    public Transform blaster;
    public GameObject laserBolt;
    public GameObject biggerLaserBolt;

    //This exists to show more than just the powerup can be in the inventory
    private void Start()
    {
        inventory.Add("Blaster");
    }


    void Update()
    {
        MovePlayer();
        WallCheck();
        LaserFire();
    }


    //moves the player
    private void MovePlayer()
    {
        //set Horizontal Input to get values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");

        //moves player left and rught
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

    }


    //keep player within bounds
    private void WallCheck()
    {   
        //Left Wall
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        //Right Wall
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }


    //fires the Laser
    private void LaserFire()
    {
        // Activates on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {

            // fires a normal laser if damageup is not active
            if (!damageUp)
            {
                // creates a laser at the position of the blaster with the rotation of the laser
                Instantiate(laserBolt, blaster.transform.position, laserBolt.transform.rotation);
            }

            // Fires a Big laser if damageup is active
            if (damageUp)
            {
                // creates a laser at the position of the blaster with the rotation of the laser
                Instantiate(biggerLaserBolt, blaster.transform.position, laserBolt.transform.rotation);

            }

            //double checks that damage up is true
            if (damageUp == false)
            {
                inventory.Remove("Damage Up");
            }
            //prints every item in the inventory in the console
            Debug.Log(string.Join(", ", inventory));
        }
    }


    //deletes any object with a trigger that hits the player
    private void OnTriggerEnter(Collider other)
    {
        // if the item is a powerup, adds it to the inventory and sets DamageUp to active
        if (other.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            inventory.Add("Damage Up");
            StartCoroutine(PowerUpTimer());
        }
        //just destroys enemies
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    //Starts a timer to turn off the powerup
    IEnumerator PowerUpTimer()
    {
        damageUp = true;
        yield return new WaitForSeconds(waitTime);
        inventory.Remove("Damage Up");
        damageUp = false;
    }
}
