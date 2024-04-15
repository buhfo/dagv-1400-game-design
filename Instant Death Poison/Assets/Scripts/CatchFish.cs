using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    public GameObject launchBob;
    public GameObject fakeBob;
    public GameObject fishReturn;
    private GameObject returnArea;
    private Vector3 returnVec;
    private float speed = 10.0f;
    private bool isReturning;

    private Rigidbody bobRb;

    private void Start()
    {
        bobRb = GetComponent<Rigidbody>();
        returnArea = GameObject.Find("Return Point");
        isReturning = false;
    }
    private void Update()
    {
        returnVec = returnArea.transform.position;

        if (isReturning == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, returnVec, speed * Time.deltaTime);
        }
        if (isReturning == true && transform.position == returnVec) 
        {
            Instantiate(launchBob, new Vector3(0, -1, 0), Quaternion.identity);
            Instantiate(fakeBob, returnVec, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fish"))
        {
            Instantiate(fishReturn, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isReturning = true;
        bobRb.isKinematic = false;
        bobRb.detectCollisions = false;
        bobRb.useGravity = false;
    }
}
