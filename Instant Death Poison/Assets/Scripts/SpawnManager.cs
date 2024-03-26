using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int spawnRange = 4;
    void Start()
    {
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
        Instantiate(fishPrefab, GenerateSpawnPos(), fishPrefab.transform.rotation);
    }

    
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(1 , spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY,spawnPosZ);
        return randomPos;
    }
}
