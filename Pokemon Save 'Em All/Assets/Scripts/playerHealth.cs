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

        if (health <= 0 && !isDead)
        {
            isDead = true;
            // Handle death here if needed
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

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Try to find UI elements in the new scene
        healthBar = GameObject.FindWithTag("HealthBar")?.GetComponent<Image>();
        healthText = GameObject.FindWithTag("HealthText")?.GetComponent<TextMeshProUGUI>();

        // Update the health UI in the new scene
        UpdateHealthUI();
    }
}
