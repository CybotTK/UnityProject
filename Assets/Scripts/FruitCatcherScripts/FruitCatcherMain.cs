using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class main : MonoBehaviour
{
    public bool GameOver;
    public GameObject gameOverText;
    public TextMeshProUGUI winnerText;
    public bool isGameActive = true;

    void Start()
    {
        GameOver = false;
        isGameActive = true;
        gameOverText.SetActive(false);
        winnerText.gameObject.SetActive(false);
    }

    public void EndGame(string winner)
    {
        GameOver = true;
        isGameActive = false;
        gameOverText.SetActive(true);
        winnerText.text = $"{winner} a câștigat!";
        winnerText.gameObject.SetActive(true); // Afișează textul câștigătorului
    }
}
