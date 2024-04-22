using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10.0f;
    private float zBound = 3.0f;
    private float xBound = 10.0f;
    private float xBoundLeft = 6.0f;
    private float spawnPosY = 13;
    private float posX;
    private float posZ;
    private bool canMove;

  
    public GameObject thrownBobber;
    public Material redMat;
    public Material greenMat;
    private Renderer selfRenders;
    private GameManager gameManager;

    private void Start()
    {
        selfRenders = GetComponent<Renderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        canMove = true;
    }


    void Update()
    {
        PlayerPosConstraints();

        if (gameManager.gameStarted == true && canMove == true && gameManager.gameOver == false)
        {
            MovePlayer();
        }
        if (Input.GetKeyDown(KeyCode.Space) && canMove == true && gameManager.gameOver == false)
        {
            posX = transform.position.x;
            posZ = transform.position.z;
            Instantiate(thrownBobber, new Vector3(posX, spawnPosY, posZ), Quaternion.identity);
            Destroy(gameObject);
        }
        if (transform.position.y != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 0, transform.position.z), (speed / 2) * Time.deltaTime);
        }
        if (Physics.Raycast(transform.position, Vector3.up, Mathf.Infinity))
        {
            selfRenders.material = greenMat;

        }
        else
        {
            selfRenders.material = redMat;
        }

    }

    // moves the launch point for the fishing rod
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * -verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * -horizontalInput * Time.deltaTime);
    }

    // stops the launch point from going too far 
    void PlayerPosConstraints()
    {
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBoundLeft)
        {
            transform.position = new Vector3(xBoundLeft, transform.position.y, transform.position.z);
        }
    }

    public void CanMoveCheck()
    {
        canMove = false;
    }


}
