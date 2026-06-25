using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;
    public int enemyKillCount;
    public int totalEnemies = 3;
    public bool isGameEnded;

    [Header("UI Texts")]
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text killText;
    public TMP_Text collectText;
    public TMP_Text messageText;

    public int collectedItems;
    public int totalCollectibles = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1f;
        isGameEnded = false;

        UpdateUI();

        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
    }

    public void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (healthText != null)
            healthText.text = "Health: " + GetPlayerHealthText();

        if (killText != null)
            killText.text = "Kills: " + enemyKillCount + " / " + totalEnemies;

        if (collectText != null)
            collectText.text = "Items: " + collectedItems + " / " + totalCollectibles;
    }

    private string GetPlayerHealthText()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();

        if (playerHealth == null)
            return "0";

        return playerHealth.GetCurrentHealth().ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void EnemyKilled()
    {
        enemyKillCount++;
        AddScore(10);
        UpdateUI();

        /*if (enemyKillCount >= totalEnemies)
        {
            WinGame();
        }*/
    }
    public void WinGameFromDoor()
    {
        WinGame();
    }

    public void CollectItem()
    {
        collectedItems++;
        UpdateUI();
    }

    private void WinGame()
    {
        if (isGameEnded) return;

        isGameEnded = true;

        if (messageText != null)
        {
            messageText.text = "You Win!";
            messageText.gameObject.SetActive(true);
        }

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GameOver()
    {
        if (isGameEnded) return;

        isGameEnded = true;

        if (messageText != null)
        {
            messageText.text = "Game Over!";
            messageText.gameObject.SetActive(true);
        }

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
}