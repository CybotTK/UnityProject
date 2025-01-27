using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedChickenScript : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites; // probs 3-4 sprites
    private int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.1f, 0.1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.up * strength;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
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

    //Animation
    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<FlappyBirdGameManager>().GameOver(); // super performance heavy maybe we use something else if we have perf issues
            GameManagerTTT.instance.AddWinningPlayer("Cyan");
            ChangeScene("Grid");
        }
    }
}
