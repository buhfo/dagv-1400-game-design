using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 25f;
    private float rotationSpeed = 100f;
    private float verticalInput;
    public GameObject prop;
    private float propSpeed = 50f;
   
    void Start()
    {

    }

    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
        // rotates the propeller 
        prop.transform.Rotate(new Vector3(0, 0, propSpeed));
    }
}
