using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBomberMan : MonoBehaviour
{
    public GameObject[] players;

    private string playerName;

    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 0f; // Pause the game
        StartCoroutine(TransitionToScene(sceneName));
    }

    private IEnumerator TransitionToScene(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1f); // Wait for 1 real-time second
        Time.timeScale = 1f; // Reset time scale before changing the scene
        SceneManager.LoadScene(sceneName);
    }

    public void CheckWinState()
    {
        int aliveCount = 0;

        foreach (GameObject player in players)
        {
            if (player.activeSelf)
            {
                aliveCount++;
                playerName = player.name;
            }
        }

        if (aliveCount <= 1)
        {
            if (playerName == "Player cyan")
            {
                Debug.Log("Instance = Cyan");
                GameManagerTTT.instance.AddWinningPlayer("Cyan");
            }
            else
            {
                Debug.Log("Instance = Red");
                GameManagerTTT.instance.AddWinningPlayer("Red");
            }
            ChangeScene("Grid");
            //Invoke(nameof(NewRound), 3f);
        }
    }

    private void NewRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

