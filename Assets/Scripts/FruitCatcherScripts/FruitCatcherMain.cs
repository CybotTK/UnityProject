using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public void LoadSceneWithDelay(string sceneName, float delay)
    {
        StartCoroutine(WaitAndLoadScene(sceneName, delay));
    }

    private IEnumerator WaitAndLoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified time
        SceneManager.LoadScene(sceneName);      // Load the target scene
    }

    public void EndGame(string winner)
    {
        GameOver = true;
        isGameActive = false;
        gameOverText.SetActive(true);
        winnerText.text = $"{winner} a câștigat!";
        winnerText.gameObject.SetActive(true); // Afișează textul câștigătorului
        if (winner == "Cyan Chicken")
        {
            Debug.Log("Cyan Chicken Won return to Grid");
            GameManagerTTT.instance.AddWinningPlayer("Cyan");
            LoadSceneWithDelay("Grid", 1.0f);
        }
        else
        {
            Debug.Log("Red" + " Chicken Won return to Grid");
            GameManagerTTT.instance.AddWinningPlayer("Red");
            LoadSceneWithDelay("Grid", 1.0f);
        }
    }
}
