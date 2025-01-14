using UnityEngine;

public class GameManagerGlobal : MonoBehaviour
{
    public PinBallGameManager manager1; 
    public PinBallGameManager2 manager2; 

    public void OnBallDeath(string ballName)
    {
        CheckWinner();
    }

    private void CheckWinner()
    {
        int player1Score = manager1.GetScore();
        int player2Score = manager2.GetScore();
        if (player1Score > player2Score)
        {
            Debug.Log("Gaina albastra won!");
        }
        else if (player2Score > player1Score)
        {
            Debug.Log("Gaina rosie won!");
        }
        else
        {
            Debug.Log("It's a draw!");
        }
    }
}
