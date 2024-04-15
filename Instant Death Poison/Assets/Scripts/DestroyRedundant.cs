using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRedundant : MonoBehaviour
{
    private float speed = 50;
    private bool launching;
    private GameObject launcher;
    private float launchToX;
    private float launchToZ;
    private GameManager gameManager;

    private void Start()
    {
        launcher = GameObject.Find("Launch location");
        launching = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        // makes sure the launcher is assigned
        if (launcher == null)
        {
            launcher = GameObject.Find("Launch location(Clone)");
        }


        // launches the fake bobber towards wherever the bobber will fall from
        if (launching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(launchToX, 13, launchToZ), speed * Time.deltaTime);

            //destroys the bobber once its out of sight.
            if (transform.position.y > 12)
            {
                Destroy(gameObject);
            }
        }

        //sets the launch location, and tells the game to launch bobber
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.gameOver  == false)
        {
            launchToX = launcher.transform.position.x / 2;
            launchToZ = launcher.transform.position.z / 2;
            launching = true;

        }
    }
}
