using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinBallGameManager : MonoBehaviour   
{
    [SerializeField]
    GameObject ball,startButton,scoreText,quitButton,restartButton;

    int score;

    [SerializeField]
    Rigidbody2D left, right;

    [SerializeField]
    Vector3 startPos;

    public int multiplier;

    bool canPlay;

    public static PinBallGameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1;
        score = 0;
        multiplier = 1;
        canPlay = false;
    }

    private void Update()
    {
        if (!canPlay) return;
        if(Input.GetKey(KeyCode.A))
        {
            left.AddTorque(25f);
        }
        else
        {
            left.AddTorque(-20f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            right.AddTorque(-25f);
        }
        else
        {
            right.AddTorque(20f);
        }

    }

    public void UpdateScore(int point, int mullIncrease)
    {
        multiplier += mullIncrease;
        score += point * multiplier;
        scoreText.GetComponent<Text>().text = "Score : " + score;
    }

    public void GameEnd()
    {
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        startButton.SetActive(false);
        scoreText.SetActive(true);
        Instantiate(ball, startPos, Quaternion.identity);
        canPlay = true;
    }

}
