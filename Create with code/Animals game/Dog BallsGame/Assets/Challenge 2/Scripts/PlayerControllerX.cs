using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public bool wait = false;
    private float spawnInterval = 0.5f;
    void Start()
    {
        
        InvokeRepeating("WaitToggle", 0, spawnInterval);

    }
        // Update is called once per frame
        void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wait == false)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                wait = true;
            }
        }
    }

    void WaitToggle()
    {
        wait = false;
    }
}
