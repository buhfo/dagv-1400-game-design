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
    private Animator mAnimator;

    void Start()
    {
        mAnimator = GameObject.Find("DerekRigged").GetComponent<Animator>();
        returnArea = GameObject.Find("Return Point");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        //starts reeling in animation
        mAnimator.SetTrigger("Reel");
    }


    void Update()
    {
        
        returnVec = returnArea.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, returnVec, speed * Time.deltaTime);
        if(transform.position == returnVec)
        {
            //starts eating fish animation
            mAnimator.SetTrigger("EatFish");
            gameManager.IsNoBobber();
            gameManager.AddToScore();
            spawnManager.FishWasCaught();
            Destroy(gameObject);
        }
    }
}
