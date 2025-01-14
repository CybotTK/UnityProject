using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealth;
    [SerializeField]
    private bool IsPlayer;
    [SerializeField]
    private string playerName; 

    [SerializeField]
    private GameObject gameOverPanel; 
    [SerializeField]
    private TMPro.TextMeshProUGUI winnerText; 

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public bool IsInvincible { get; set; }
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    private void Start()
    {
        if (OnDied == null)
        {
            OnDied = new UnityEvent();
        }

        OnDied.AddListener(StopGameOnDeath);
    }

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }

        _currentHealth -= damageAmount;
        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;
        OnHealthChanged.Invoke();
        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
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

    private void StopGameOnDeath()
    {
        if (IsPlayer)
        {
            Debug.Log("Game Over! Player has died.");

            if (gameOverPanel != null)
            {
                string winner = playerName == "Gaina rosie" ? "Gaina albastra" : "Gaina rosie";
                gameOverPanel.SetActive(true);
                winnerText.text = $"{winner} a câștigat !";
                if (winner == "Gaina albastra") GameManagerTTT.instance.AddWinningPlayer("Cyan");
                else GameManagerTTT.instance.AddWinningPlayer("Red");
                LoadSceneWithDelay("Grid", 1.0f);
            }
        }
    }
}
