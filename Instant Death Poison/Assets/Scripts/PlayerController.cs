using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 10.0f;
    private float zBound = 3.0f;
    private float xBound = 10.0f;
    private float yBound = -6.0f;
    private float xBoundLeft = 6.0f;
    private float spawnPosY = 13;
    private Vector3 posReal;
    private float posX;
    private float posY;
    private float posZ;


    public GameObject thrownBobber;
    public Material redMat;
    public Material greenMat;
    private Renderer selfRenders;
    private GameManager gameManager;
    private Animator mAnimator;



    private void Start()
    {
        //finds the gamemanager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        //gets the renderer
        selfRenders = GetComponent<Renderer>();

        //gets the animator for derek
        mAnimator = GameObject.Find("DerekRigged").GetComponent<Animator>();
    }


    void Update()
    {
        //verifies the game is actually going before handing over the controls
        if (gameManager.gameStarted == true && gameManager.gameOver == false)
        {
            posReal = transform.position;
            posX = transform.position.x;
            posY = transform.position.y;
            posZ = transform.position.z;
            PlayerPosConstraints();
            MovePlayer();
            LaunchBobber();
            ColorChanger();

        }
    }


    void PlayerPosConstraints()//stops players from going out of bounds
    {
        //keeps players from exiting towards the camera
        if (posZ > zBound)
        {
            posReal = new Vector3(posX, posY, zBound);
        }

        // keeps players from exiting the sides
        if (posX < -xBound)
        {
            posReal = new Vector3(-xBound, posY, posZ);
        }
        if (posX > xBoundLeft)
        {
            posReal = new Vector3(xBoundLeft, posY, posZ);
        }

        // makes sure the player doesnt fall out of the screen
        if (posY < yBound)
        {
            posReal = Vector3.MoveTowards(transform.position, new Vector3(posX, yBound, posZ), (speed / 2) * Time.deltaTime);
            posReal = new Vector3(posX, yBound, posZ);
        }
    }

    void OnTriggerEnter(Collider other)//keeps player above ground
    {
        if (other.CompareTag("Ground"))
        {
            posReal = new Vector3(posX, (posY + 0.1f), posZ);
        }
    }

    void LaunchBobber()// launches the bobber
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            mAnimator.SetTrigger("CastLine");
            Instantiate(thrownBobber, new Vector3(posX, spawnPosY, posZ), Quaternion.identity);
            posReal = Vector3.MoveTowards(transform.position, new Vector3(posX, yBound - 2, posZ), (speed / 2) * Time.deltaTime);
            gameObject.SetActive(false);
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

    void ColorChanger() // swaps players colors if under a fish
    {
        if (Physics.Raycast(transform.position, Vector3.up, Mathf.Infinity))
        {
            selfRenders.material = greenMat;
        }
        else
        {
            selfRenders.material = redMat;
        }
    }
}
