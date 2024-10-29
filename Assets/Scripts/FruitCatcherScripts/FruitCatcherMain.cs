using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class main : MonoBehaviour
{
    public int score;
    public bool GameOver;
    public Transform title;
    public TextMeshProUGUI scoreboard;
    public GameObject gameOverText;


    void Start()
    {
        score = 0;
        GameOver = false;
        scoreboard.text = "0";
        gameOverText.SetActive(false);
    }

   
    void Update()
    {
        if(GameOver == true)
        {
            title.localPosition = new Vector3(0f, 0f, 0f);
            GameOver = false;
        }
    }

    public void AddScore()
    {
        score++;
        scoreboard.text = score.ToString();
    }

    public void GameOverMenu()
    {
        GameOver = true;
        gameOverText.SetActive(true);
    }
}
