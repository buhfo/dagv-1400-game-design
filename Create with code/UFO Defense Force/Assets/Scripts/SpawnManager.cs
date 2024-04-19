using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject damageUp;
    public GameObject enemies;

    private float spawnRangeX = 15;
    private float ySpawn = 1;
    private float zSpawn = 20;
    private float startDelay = 1;
    private float spawnInterval = 8;
    private float lowEnd = 0;
    private float highEnd = 6;
    private float maxNum = 10;

    public bool canSpawn;

    void Start()
    {
        // makes it so every 5 seconds or so it calls the canspawn function
        InvokeRepeating("CanSpawn", startDelay, spawnInterval);
    }

    private void Update()
    {
        SpawnPowerUp();
    }

    // spawns the powerup
    void SpawnPowerUp()
    {
        //if the powerup can spawn, spawns it
        if (canSpawn)
        {
            // sets the spawn position to be a random place within a range of my choice
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), ySpawn, zSpawn);
            //Spawns the powerup
            Instantiate(damageUp, spawnPos, damageUp.transform.rotation);
        }
        //stops the powerup from being continually spawned after one 
        canSpawn = false;
    }

    // sets the can spawn bool to be true
    void CanSpawn()
    {
        // basically flips a coin to see if can spawn will be true
        if (Random.Range(lowEnd, maxNum) > highEnd)
        {
            canSpawn = true;
        }
    }
}
