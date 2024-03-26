using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMover : MonoBehaviour
{

    private int speed;
    private int waitTime;
    private bool countdownGoing = true;
    
    void Start()
    {
        StartCoroutine(FishTurnCountdown());
        speed = Random.Range(1, 4);
        waitTime = Random.Range(1, 4);
    }


    void Update()
    {
        transform.Translate(Vector3.up * -speed * Time.deltaTime);

        if (countdownGoing == false)
        {
            StartCoroutine(FishTurnCountdown());
            countdownGoing=true;
        }
    }

    IEnumerator FishTurnCountdown()
    {
        yield return new WaitForSeconds(waitTime);
        countdownGoing = false;
        transform.Rotate(180,0,0);
    }
}
