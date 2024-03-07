using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {   
        // destroys objects when they collide
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
