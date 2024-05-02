using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fishPrefab;
    private GameManager gameManager;
    public int spawnRange = 3;
    public int currentCount;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        if (currentCount < 1 && gameManager.gameStarted == true)// checks to see if fish need to be spawned
        {
            SpawnFishies();
        }
    }

    private Vector3 GenerateSpawnPos()//generates spawn positions
    {
        float spawnPosX = Random.Range(-spawnRange, 0);
        float spawnPosY = Random.Range(-5 , spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, 4);

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY,spawnPosZ);
        return randomPos;
    }

    public void SpawnFishies()// spawns 4 fish in random positions
    {
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
        currentCount = 4;
    }

    public void FishWasCaught()// lowers fish count
    {
        currentCount--;
    }
}
