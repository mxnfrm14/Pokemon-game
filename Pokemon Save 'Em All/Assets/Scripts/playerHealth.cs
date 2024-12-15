using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Add this for TextMeshPro

public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText; // Reference to the TextMeshPro component
    public GameManagerScript gameManager;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        UpdateHealthUI(); // Initialize the health bar and text
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        UpdateHealthUI();

        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
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
}
