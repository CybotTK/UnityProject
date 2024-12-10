using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public int score = 0; 
    public TMPro.TextMeshProUGUI scoreText; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            score += 10;
            UpdateScore();
            Destroy(collision.gameObject);
        }
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
