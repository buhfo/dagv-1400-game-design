using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public GameObject launchBob;
    public GameObject fakeBob;
    public GameObject fishReturn;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish")) // if its a fish instantiate return
        {
            Instantiate(fishReturn, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)// return player controls and destroy bobber
    {
        gameManager.IsNoBobber();
        Destroy(gameObject);
    }
}
