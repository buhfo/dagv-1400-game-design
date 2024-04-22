using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score; // keeps actual score value

    public TextMeshProUGUI scoreText; // is the visual text that will be modified

    public void IncreaseScore(int amount)//adds to score
    {
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseScore(int amount)//subtracts from score
    {
        score -= amount;
        UpdateScoreText();
    }

    public void UpdateScoreText() // changes the visual score text
    {
        scoreText.text = "Score: " + score;
    }
}
