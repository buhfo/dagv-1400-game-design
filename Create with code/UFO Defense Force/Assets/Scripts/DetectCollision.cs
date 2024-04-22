using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject); // destroy other gameobject
        }
        Destroy(gameObject); // destroy this gameobject
    }


}