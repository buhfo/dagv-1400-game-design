using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    private GameObject gameOverText;

    public AudioClip gameOverSound;

    private AudioSource gameManAudio;

    void Awake()
    {
        Time.timeScale = 1.0f;
        isGameOver = false;
    }
    void Start()
    {
        gameManAudio = GetComponent<AudioSource>();
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
        gameManAudio.PlayOneShot(gameOverSound, 1.0f);
        Time.timeScale = 0.0f;// freeze time
    }
}
