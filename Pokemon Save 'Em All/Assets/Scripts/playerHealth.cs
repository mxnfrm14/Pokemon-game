using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public static playerHealth Instance { get; private set; } // Singleton instance

    public float health;
    public float maxHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    private bool isDead;
    public GameManagerScript gameManager;

    void Awake()
    {
        // Ensure a single instance persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        maxHealth = health;
        UpdateHealthUI(); // Initialize the health bar and text
    }

    void Update()
    {
        UpdateHealthUI();

        // If health reaches 0 and the player isn't already dead
        if (health <= 0 && !isDead)
        {
            isDead = true;
            if (gameManager != null)
            {
                gameManager.gameOver(); // Call the game over logic
            }
            else
            {
                Debug.LogError("gameManager is null when health reaches 0! Ensure it's assigned.");
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }
        if (healthText != null)
        {
            healthText.text = Mathf.Clamp(health, 0, maxHealth).ToString();
        }
    }

    public void UpdateHealth(float newHealth)
    {
        health = newHealth;
        UpdateHealthUI();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method is called whenever a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Use tag to find the GameManager in the scene
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManagerTag");

        // Check if GameManager was found and assign it
        if (gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManagerScript>();
            Debug.Log("GameManager successfully found and assigned.");
        }
        else
        {
            Debug.LogError("GameManager not found in the scene with the specified tag.");
        }

        // Optionally, try to find UI elements in the new scene if needed
        healthBar = GameObject.FindWithTag("HealthBar")?.GetComponent<Image>();
        healthText = GameObject.FindWithTag("HealthText")?.GetComponent<TextMeshProUGUI>();

        // Update the health UI
        UpdateHealthUI();
    }

    public void ResetHealthToDefault()
    {
        health = 100;  // Reset to 100 only when restarting or respawning
        isDead = false; // Reset the dead flag
        UpdateHealthUI();
    }
}
