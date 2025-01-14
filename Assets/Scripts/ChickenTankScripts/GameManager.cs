using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; // pentru a reîncărca scena

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI winnerText; 

    public PlayerController player1;
    public PlayerController player2;
    private bool player1Died = false;
    private bool player2Died = false;

    private bool isDraw = false;

    private int player1FinalScore = 0;
    private int player2FinalScore = 0;

    void Start()
    {
        // Resetăm timpul jocului când scena este reîncărcată
        Time.timeScale = 1f;

        // Căutăm obiectele jucătorilor din scenă folosind tag-uri
        GameObject player1Object = GameObject.FindWithTag("Player1");
        GameObject player2Object = GameObject.FindWithTag("Player2");

        // Verificăm dacă am găsit obiectele
        if (player1Object != null)
        {
            player1 = player1Object.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("Player 1 not found!"); // Afișăm un mesaj de eroare dacă nu găsim Player 1
        }

        if (player2Object != null)
        {
            player2 = player2Object.GetComponent<PlayerController>();
        }
        else
        {
            Debug.LogError("Player 2 not found!"); // Afișăm un mesaj de eroare dacă nu găsim Player 2
        }

        // Verificăm dacă jucătorii există și sunt corect atașați
        if (player1 == null || player2 == null)
        {
            Debug.LogError("One or both players are not properly assigned!");
        }

        winnerText.gameObject.SetActive(false); // Ascunde textul câștigătorului la început
    }

    public void PlayerDied(GameObject playerObject)
    {
        if (playerObject == player1?.gameObject)
        {
            player1Died = true;
            player1FinalScore = player1.score; 
            player1 = null; // Eliminăm referința
        }
        else if (playerObject == player2?.gameObject)
        {
            player2Died = true;
            player2FinalScore = player2.score; 
            player2 = null; 
        }

        // Dacă ambii jucători au murit, compara scorurile
        if (player1Died && player2Died)
        {
            CompareScores();
        }
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

    void CompareScores()
    {
        
        if (player1FinalScore > player2FinalScore)
        {
            winnerText.text = "Player 1 Wins!";
            GameManagerTTT.instance.AddWinningPlayer("Cyan");
            LoadSceneWithDelay("Grid", 1.0f);
        }
        else if (player2FinalScore > player1FinalScore)
        {
            winnerText.text = "Player 2 Wins!"; 
            GameManagerTTT.instance.AddWinningPlayer("Red");
            LoadSceneWithDelay("Grid", 1.0f);
        }
        else
        {
            winnerText.text = "It's a Draw! Press R to restart.";
            isDraw = true;
        }

        winnerText.gameObject.SetActive(true); 
    }

    void Update()
    {
        // Dacă este remiză și jucătorul apasă R, reîncarcă scena
        if (isDraw && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
