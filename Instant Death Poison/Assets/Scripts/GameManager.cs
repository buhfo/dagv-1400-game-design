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
    private float timer = 10;
    private float finalScore;
    private float currentScore;
    private float waitTime = 1;
    public bool noBobber = false;
    public bool gameOver;
    public bool gameStarted;
    public bool addedOne;

    private Vector3 returnVec;

    private GameObject returnArea;
    private PlayerController playerController;
    private Animator mAnimator;




    private void Start()
    {
        // Makes sure the player cant move before the game is started
        gameStarted = false;

        //finds the return point so it can be referenced later
        returnArea = GameObject.Find("Return Point");

        //finds the player controller
        playerController = GameObject.Find("Launch location").GetComponent<PlayerController>();

        // makes sure the timer and score arent visible before the game starts
        timeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);

        noBobber = true;

        mAnimator = GameObject.Find("DerekRigged").GetComponent<Animator>();
    }

    private void Update()
    {
        if (gameStarted && !gameOver)
        {
            CountDown();
            BobberCheck();
        }
        GameFinished();
    }

    IEnumerator ScoringSpeed() // makes it so the counter goes up one at a time
    {
        yield return new WaitForSeconds(waitTime);
        currentScore++;
    }
    private void GameFinished() // logs the scores and activates all UI elements
    {
        //checks if you ran out of time, or won the game
        if (timer <= 0 || score >= 100)
        {
            currentScore = score;
            finalScore = score + timer;
            gameOver = true;
            restartButton.gameObject.SetActive(true);
            vicText.gameObject.SetActive(true);
            finalScoreText.gameObject.SetActive(true);
            actualFinalScoreText.gameObject.SetActive(true);
            actualFinalScoreText.text = "" + currentScore;
            if (currentScore <= finalScore)
            {
                StartCoroutine(ScoringSpeed());
                actualFinalScoreText.text = "" + currentScore;
            }
        }
    }
    private void CountDown() // starts countdown when game is started, also updates score/time text
    {
        timer -= Time.deltaTime;
        timeText.text = "" + Mathf.RoundToInt(timer);
        scoreText.text = "Fish Caught: " + score + "/100";
    }
    private void BobberCheck()// makes sure a bobber is in the scene
    {

        if (noBobber == true) //respawns the bobber
        {
            returnVec = returnArea.transform.position;
            playerController.gameObject.SetActive(true);
            Instantiate(fakeBob, returnVec, Quaternion.identity);
            noBobber = false;
            mAnimator.SetTrigger("Return");
        }
        //if (playerController == null) // before spawning a new bobber it looks for one with a different name
        //{
        //    playerController = GameObject.Find("Launch location(Clone)").GetComponent<PlayerController>();
        //}
    }
    public bool IsNoBobber()// toggles isBobber Bool
    {
        noBobber = true;
        return noBobber;
    }
    public void AddToScore()// controls adding to score
    {
        score++;
        timer += 5;
    }
    public void RestartGame()// restarts the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameStarter()// starts the game
    {
        gameStarted = true;
        timeText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }
}
