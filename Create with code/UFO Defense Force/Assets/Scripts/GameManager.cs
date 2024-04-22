using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    private GameObject gameOverText;
    void Awake()
    {
        Time.timeScale = 1.0f;
        isGameOver = false;
    }
    void Start()
    {
        gameOverText = GameObject.Find("GameOverText");
    }

    void Update()
    {
        if (isGameOver)
        {
            EndGame();
        }
        else 
        { 
            gameOverText.gameObject.SetActive(false); //hides game over text 
        }
    }

    public void EndGame()
    {
        gameOverText.gameObject.SetActive(true);// shows game over
        Time.timeScale = 0.0f;// freeze time
    }
}
