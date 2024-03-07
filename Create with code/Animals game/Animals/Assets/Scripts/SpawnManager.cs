using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;
    private float spawnInterval = 1.5f;
    private float startDelay = 2;

    void Start()
    {
        // makes it so that the animals get spawned repeatedly after 2 seconds
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }
    void SpawnRandomAnimal()
    {
        // Generates a random number in the array
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        // sets the spawn position to be a random place within a range of my choice
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        //Spawns the animal
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
