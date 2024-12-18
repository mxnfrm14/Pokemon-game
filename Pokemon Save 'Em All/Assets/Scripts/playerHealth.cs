using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public static playerHealth Instance { get; private set; } // Singleton instance

    public float health;
    public float maxHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public GameManagerScript gameManager;
    private bool isDead;

    void Awake()
    {
        // Ensure that there's only one instance of playerHealth
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Make this object persistent between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        UpdateHealthUI(); // Initialize the health bar and text
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }
        UpdateHealthUI();

        if (health <= 0 && !isDead)
        {
            isDead = true;
            if (gameManager != null)
            {
                gameManager.gameOver();
            }
        }
    }

    // Updates the health text and ensures it reflects the current health
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = Mathf.Clamp(health, 0, maxHealth).ToString();
        }
    }

    // Method to update health from Unit script
    public void UpdateHealth(float newHealth)
    {
        health = newHealth;
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        }
        UpdateHealthUI();
    }
}