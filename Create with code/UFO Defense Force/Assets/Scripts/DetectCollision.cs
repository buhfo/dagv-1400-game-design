using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ScoreManager scoreManager; // store reference to score manager

    public int scoreToGive;

    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            scoreManager.IncreaseScore(scoreToGive);
            Destroy(other.gameObject); // destroy other gameobject
            Destroy(gameObject); // destroy this gameobject
        }
        if (other.gameObject.CompareTag("BigLaser"))
        {
            scoreManager.IncreaseScore(scoreToGive * 2);
            Destroy(gameObject); // destroy this gameobject
        }
    }


}