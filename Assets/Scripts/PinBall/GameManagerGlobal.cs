using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerGlobal : MonoBehaviour
{
    public PinBallGameManager manager1; 
    public PinBallGameManager2 manager2; 

    public void OnBallDeath(string ballName)
    {
        CheckWinner();
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

    private void CheckWinner()
    {
        int player1Score = manager1.GetScore();
        int player2Score = manager2.GetScore();
        if (player1Score > player2Score)
        {
            Debug.Log("Gaina rosie won!");
            GameManagerTTT.instance.AddWinningPlayer("Red");
            LoadSceneWithDelay("Grid", 1.0f);
        }
        else if (player2Score > player1Score)
        {
            Debug.Log("Gaina albastra won!");
            GameManagerTTT.instance.AddWinningPlayer("Cyan");
            LoadSceneWithDelay("Grid", 1.0f);
        }
        else
        {
            Debug.Log("It's a draw! WE DID NOT THINK IT WOULD ACTUALLY BE WTF");
        }
    }
}
