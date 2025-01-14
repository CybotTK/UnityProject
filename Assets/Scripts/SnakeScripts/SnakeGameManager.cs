﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SnakeGameManager : MonoBehaviour
{
    /*public float startTime = 10f;
    private float timeRemaining;
    public TextMeshProUGUI timerText;*/
    public TextMeshProUGUI winnerText;

    // scoruri pentru fiecare jucător
    public TextMeshProUGUI scoreRedText;
    public TextMeshProUGUI scoreBlueText;

    // scoruri pentru SnakeRed și SnakeCyan
    public SnakeRed snakeRed;
    public SnakeCyan snakeCyan;

    void Start()
    {
        /*timeRemaining = startTime;
        DisplayTime(timeRemaining);*/
        winnerText.gameObject.SetActive(false);
    }

    void Update()
    {
       /* if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            Debug.Log("Timer ended!");
        }*/

        // Actualizare scoruri
        DisplayScores();
    }

    /*void DisplayTime(float timeToDisplay)
    {
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/

    void DisplayScores()
    {
        // Afișăm scorurile celor doi șerpi
        scoreRedText.text = snakeRed.GameScore().ToString();
        scoreBlueText.text =snakeCyan.GameScore().ToString();
    }

    public void DisplayWinner(string winner)
    {
        winnerText.text = $"{winner} a câștigat!";
        winnerText.gameObject.SetActive(true);
        if (winner == "SnakeCyan")
        {
            Debug.Log("Instance = Cyan");
            GameManagerTTT.instance.AddWinningPlayer("Cyan");
        }
        else
        {
            Debug.Log("Instance = Red");
            GameManagerTTT.instance.AddWinningPlayer("Red");
        }
        SceneManager.LoadScene("Grid");
    }

}
