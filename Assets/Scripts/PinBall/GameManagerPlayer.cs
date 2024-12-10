using UnityEngine;

public class GameManagerPlayer : MonoBehaviour
{
    public BallBehavior player1Ball;
    public BallBehavior player2Ball;

    public void Update()
    {
        if (player1Ball.transform.position.y < -5f || player2Ball.transform.position.y < -5f)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        string winner = player1Ball.score > player2Ball.score ? "Player 1 Wins!" : "Player 2 Wins!";
        Debug.Log(winner);
        Time.timeScale = 0; 
    }
}
