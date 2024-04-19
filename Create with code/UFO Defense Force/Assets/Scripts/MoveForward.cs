using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        //moves gameobject forward
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
