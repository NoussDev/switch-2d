using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : GameManager
{
    public int scoreValue = 0;
    public float timerValue = 5;

    

    private Text scoreText;
    private Text timerText;
    private Text gameOverText;
    private Button retryButton;


    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        retryButton = GameObject.Find("RetryButton").GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if(timerValue < 0)
        {
            GameManager.endGame = true;
            gameOverText.gameObject.SetActive(true);
            retryButton.gameObject.SetActive(true);
        }
        else
        {
            GameManager.endGame = false;
            gameOverText.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
            scoreText.text = "Score : " + scoreValue;
            timerValue -= Time.deltaTime;
            timerText.text = "Time : " + Mathf.Round(timerValue);
        }
    }
}
