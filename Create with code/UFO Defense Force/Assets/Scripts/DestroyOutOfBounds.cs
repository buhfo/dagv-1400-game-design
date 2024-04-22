using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOutOfBounds : MonoBehaviour
{
    private GameManager gameManager;
    private float topBounds = 30.0f;
    private float lowerBounds = -10;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBounds && gameObject.CompareTag("Enemy"))
        {
            gameManager.isGameOver = true; 
            Destroy(gameObject);
            Time.timeScale = 0f;
        }
    }
}
