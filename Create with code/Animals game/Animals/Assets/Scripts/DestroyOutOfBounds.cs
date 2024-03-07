using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    void Update()
    {
        // if something is too high up it gets removed (Projectile)
        if(transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        //If it goes too low its destroyed and a game over is displayed
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            Debug.Log("GAME OVER!");
        }
    }
}
