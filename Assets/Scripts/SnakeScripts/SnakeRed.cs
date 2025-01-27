﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SnakeRed : MonoBehaviour
{
    Vector2 direction;
    public GameObject segment;
    public List<GameObject> segments = new List<GameObject>();
    public SnakeGameManager gameManager;
    private int score =0;


    void Start()
    {
        Reset();
        gameManager = GameObject.Find("SnakeGameManager").GetComponent<SnakeGameManager>();


    }

    void Reset()
    {
        transform.position = new Vector2(-1, 4);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        direction = Vector2.right;
        Time.timeScale = 0.05f;
        resetSegments();
    }

    void resetSegments()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i]);
        }

        segments.Clear();
        segments.Add(gameObject);

        for (int i = 0; i < 3; i++)
        {
            grow();
        }
    }

    void grow()
    {
        // Crează un nou segment și dezactivează coliziunea cu capul
        GameObject newSegment = Instantiate(segment);
        newSegment.transform.position = segments[segments.Count - 1].transform.position;
        segments.Add(newSegment);

        // Dezactivează coliziunea între cap și segmentul nou
        Collider2D headCollider = GetComponent<Collider2D>();
        Collider2D segmentCollider = newSegment.GetComponent<Collider2D>();

        if (headCollider != null && segmentCollider != null)
        {
            Physics2D.IgnoreCollision(headCollider, segmentCollider, true);
        }

        
    }

    public int GameScore()
    {
        return score;
    }




    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }



    void FixedUpdate()
    {
        moveSegments();
        moveSnake();
    }

    void moveSegments()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].transform.localPosition = Vector3.zero;
            segments[i].transform.position = segments[i - 1].transform.position;
        }
    }

    void moveSnake()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            Debug.Log("SnakeRed a pierdut, a lovit un obstacol!");
            if (gameManager != null)
            {
                gameManager.DisplayWinner("SnakeCyan");
                Debug.Log("Apelare DisplayWinner din SnakeRed");
            }
        }
        else if (other.tag == "CyanSegment")
        {
            Debug.Log("SnakeRed a pierdut, a lovit SnakeCyan!");
            if (gameManager != null)
            {
                gameManager.DisplayWinner("SnakeCyan");
            }
        }
        else if (other.tag == "Food")
        {
            grow();
            score++;
        }
    }


}
