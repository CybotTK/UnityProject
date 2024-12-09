using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Viteza de mișcare
    public KeyCode upKey;    // Tasta pentru mișcarea în sus
    public KeyCode downKey;  // Tasta pentru mișcarea în jos
    public KeyCode leftKey;  // Tasta pentru mișcarea în stânga
    public KeyCode rightKey; // Tasta pentru mișcarea în dreapta

    public int score;
    public float size = 0.4f;
    private Transform tr;

    public TextMeshProUGUI scoreText;

    private bool isAlive = true;
    private GameManager gameManager;


    void Start()
    {
        tr = GetComponent<Transform>();
        UpdateSize(); // Setează dimensiunea inițială
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }



    void Update()
    {
        if (isAlive)
        {
            Vector2 moveDirection = Vector2.zero;

            // Detectează tastele apăsate și setează direcția
            if (Input.GetKey(upKey)) moveDirection.y += 1;
            if (Input.GetKey(downKey)) moveDirection.y -= 1;
            if (Input.GetKey(leftKey)) moveDirection.x -= 1;
            if (Input.GetKey(rightKey)) moveDirection.x += 1;

            // Aplică mișcarea
            transform.Translate(moveDirection * speed * Time.deltaTime);

            Vector3 clampedPosition = Camera.main.WorldToViewportPoint(transform.position);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, 0.01f, 1.0f); // Margini laterale
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0.05f, 0.95f); // Margini sus-jos
            transform.position = Camera.main.ViewportToWorldPoint(clampedPosition);

            
            scoreText.text = "" + score.ToString();
        }
    }

    void UpdateSize()
    {
        size = 0.4f + score * 0.005f; // creste dimensiunea pe baza scorului
        tr.localScale = new Vector3(size, size, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int fishPoints = 0;
        int fishLevel = 0;

        // Verifică fiecare tip de pește
        if (collision.GetComponent<Fish1>() != null)
        {
            fishPoints = 3;
            fishLevel = 1;
        }
        else if (collision.GetComponent<Fish2>() != null)
        {
            fishPoints = 5;
            fishLevel = 2;
        }
        else if (collision.GetComponent<Fish3>() != null)
        {
            fishPoints = 7;
            fishLevel = 3;
        }
        else if (collision.GetComponent<Fish4>() != null)
        {
            fishPoints = 9;
            fishLevel = 4;
        }
        else if (collision.GetComponent<Fish5>() != null)
        {
            fishPoints = 11;
            fishLevel = 5;
        }

        // Dacă e un pește valid
        if (fishLevel > 0)
        {
            if (CanEatFish(fishLevel))
            {
                IncreaseScore(fishPoints);
                Destroy(collision.gameObject); // Distruge peștele
            }
            else
            {
                LoseGame(); // Jucătorul pierde
            }
        }

        // Verifică coliziunea cu bomba
        if (collision.GetComponent<Bomb>() != null)
        {
            LoseGame(); // Jucătorul pierde la coliziune cu bomba
        }
    }

    // Verifică dacă jucătorul poate mânca peștele
    bool CanEatFish(int fishLevel)
    {
        return fishLevel switch
        {
            1 => score >= 0,
            2 => score >= 21,
            3 => score >= 60,
            4 => score >= 100,
            5 => score >= 200,
            _ => false,
        };
    }

    // Crește scorul și actualizează dimensiunea
    void IncreaseScore(int points)
    {
        score += points;
        UpdateSize();
    }



    void LoseGame()
    {
        if (isAlive)
        {
            isAlive = false;
            gameManager.PlayerDied(gameObject); // Transmite referința înainte de distrugere
            Destroy(gameObject); // Distruge jucătorul
        }
    }






}
