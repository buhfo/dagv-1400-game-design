using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishReturn : MonoBehaviour
{

    private float speed = 10;
    private Vector3 returnVec;
    private GameObject returnArea;
    public GameObject launchBob;
    public GameObject fakeBob;
    private GameManager gameManager;
    private SpawnManager spawnManager;

    void Start()
    {
        returnArea = GameObject.Find("Return Point");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }


    void Update()
    {
        returnVec = returnArea.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, returnVec, speed * Time.deltaTime);
        if(transform.position == returnVec)
        {
            gameManager.IsNoBobber();
            gameManager.AddToScore();
            spawnManager.FishWasCaught();
            Destroy(gameObject);
        }
    }
}
