using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 30f;
    [SerializeField] private float turnSpeed = 30f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Moves the vehicle forward //
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Turns the vehicle //
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
