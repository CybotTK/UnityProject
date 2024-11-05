﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject ball;

    [Header("Player1")]
    public GameObject player1;
    public GameObject Player1Goal;

    [Header("Player2")]
    public GameObject player2;
    public GameObject Player2Goal;

    [Header("UI")]
    public GameObject player1Text;
    public GameObject player2Text;
    public TextMeshProUGUI winnerText;

    private int player1Score;
    private int player2Score;
    private bool gameActive = true;

    public void Start()
    {
        winnerText.gameObject.SetActive(false);
    }

    public bool IsGameActive()
    {
        return gameActive; 
    }

    public void Player1Scored()
    {
        if (!gameActive) return; // Dacă jocul nu este activ, ieși din funcție

        player1Score++;
        player1Text.GetComponent<TMPro.TextMeshProUGUI>().text = player1Score.ToString();
        Winner();
        ResetPosition();
    }

    public void Player2Scored()
    {
        if (!gameActive) return; // Dacă jocul nu este activ, ieși din funcție

        player2Score++;
        player2Text.GetComponent<TMPro.TextMeshProUGUI>().text = player2Score.ToString();
        Winner();
        ResetPosition();
    }

    private void Winner()
    {
        if (player1Score == 5)
        {
            gameActive = false;
            winnerText.text = "Winner: Player 1!";
            winnerText.gameObject.SetActive(true); // Afișează textul câștigătorului
        }
        else if (player2Score == 5)
        {
            gameActive = false;
            winnerText.text = "Winner: Player 2!";
            winnerText.gameObject.SetActive(true); // Afișează textul câștigătorului
        }
    }

    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1.GetComponent<Paddle>().Reset();
        player2.GetComponent<Paddle>().Reset();
    }
}