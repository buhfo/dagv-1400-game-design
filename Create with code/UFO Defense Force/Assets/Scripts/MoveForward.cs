using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        MoveObject();
    }

    //Moves the object
    void MoveObject()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
