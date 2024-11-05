using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBirdGameManager : MonoBehaviour
{
    public GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;

    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);

        Pause();
    }

    private void Start()
    {
        gameOver.SetActive(false);

        Time.timeScale = 1f;
    }
}
