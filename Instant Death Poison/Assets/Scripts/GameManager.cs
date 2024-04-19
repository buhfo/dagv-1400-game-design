using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.WSA;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SocialPlatforms;
using System.Threading;
using Unity.Profiling.Editor;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScreen;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI vicText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI actualFinalScoreText;
    public GameObject launchBob;
    public GameObject fakeBob;
    public Button restartButton;
    public Button startButton;

    private float score;
    private float timer;
    private float finalScore;
    private float currentScore;
    private float waitTime = 1;
    public bool noBobber;
    public bool gameOver;
    public bool gameStarted;
    public bool addedOne;

    private Vector3 returnVec;

    private GameObject returnArea;
    private PlayerController playerController;





    private void Start()
    {
        gameStarted = false;
        noBobber = false;
        timer = 3;
        returnArea = GameObject.Find("Return Point");
        playerController = GameObject.Find("Launch location").GetComponent<PlayerController>();
        timeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (gameStarted && !gameOver)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (noBobber == true)
            {
                Instantiate(launchBob, new Vector3(0, -1, 0), Quaternion.identity);
                Instantiate(fakeBob, returnVec, Quaternion.identity);
                noBobber = false;
            }



            returnVec = returnArea.transform.position;

            if (timer <= 0)
            {
                gameOver = true;
                currentScore = score;
                finalScore = score + timer;
                playerController.CanMoveCheck();
                gameOverScreen.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                finalScoreText.gameObject.SetActive(true);
                actualFinalScoreText.gameObject.SetActive(true);
            }

            if (score >= 100) 
            {
                currentScore = score;
                finalScore = score + timer;
                gameOver = true;
                restartButton.gameObject.SetActive(true);
                vicText.gameObject.SetActive(true);
                finalScoreText.gameObject.SetActive(true);
                actualFinalScoreText.gameObject.SetActive(true);
            }

            timeText.text = "" + Mathf.RoundToInt(timer);
            scoreText.text = "Fish Caught: " + score + "/100";
            if (playerController == null)
            {
                playerController = GameObject.Find("Launch location(Clone)").GetComponent<PlayerController>();
            }
        }
        if(gameOver)
        {
            actualFinalScoreText.text = "" + currentScore;
            if (currentScore <= finalScore)
            {
                StartCoroutine(ScoringSpeed());
                actualFinalScoreText.text = "" + currentScore;
            }
        }
    }


    IEnumerator ScoringSpeed()
    {
        yield return new WaitForSeconds(waitTime);
        currentScore++;
    }



    public bool IsNoBobber()
    {
        noBobber = true;
        return noBobber;
    }
    public void AddToScore()
    { 
        score++;
        timer += 5;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameStarter()
    {
        gameStarted = true;
        timeText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }
}
