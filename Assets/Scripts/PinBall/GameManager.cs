using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinBallGameManager : MonoBehaviour   
{
    [SerializeField]
    GameObject ball,scoreText;

    int score;

    [SerializeField]
    Rigidbody2D left, right;

    [SerializeField]
    Transform leftWall, rightWall;

    public int multiplier;

    bool canPlay;

    public static PinBallGameManager instance;
    public GameManagerGlobal gameManager;

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

        GameStart();
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

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int point, int mullIncrease)
    {
        multiplier += mullIncrease;
        score += point * multiplier;
        scoreText.GetComponent<Text>().text = "Score : " + score;
    }

    public void GameEnd()
    {
        gameManager.OnBallDeath("Ball1");
    }

    public void GameStart()
    {
        scoreText.SetActive(true);

        Vector3 randomStartPos = GetRandomStartPosition();
        Instantiate(ball, randomStartPos, Quaternion.identity);
        canPlay = true;
    }

    private Vector3 GetRandomStartPosition()
    {
      
        float leftLimit = leftWall.position.x;
        float rightLimit = rightWall.position.x;

       
        float randomX = Random.Range(leftLimit, rightLimit);

        float yPos = 7; 
        float zPos = 0f;

        return new Vector3(randomX, yPos, zPos);
    }

}
