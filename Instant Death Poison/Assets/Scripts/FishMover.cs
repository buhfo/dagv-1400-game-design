using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMover : MonoBehaviour
{

    private int speed;
    private int waitTime;
    private bool countdownGoing = true;
    private GameManager gameManager;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(FishTurnCountdown());
        speed = Random.Range(1, 4);
        waitTime = Random.Range(1, 6);
    }


    void Update()
    {
        if (gameManager.gameOver == false) // lets fish move
        {
            transform.Translate(Vector3.left * -speed * Time.deltaTime);

            if (countdownGoing == false) //checks if the countdown is going
            {
                StartCoroutine(FishTurnCountdown());
                
                countdownGoing = true;
            }
        }
    }

    IEnumerator FishTurnCountdown()//rotates fish after set amount of time
    {
        yield return new WaitForSeconds(waitTime);
        transform.Rotate(0, 180, 0);
        countdownGoing = false;
    }
}
