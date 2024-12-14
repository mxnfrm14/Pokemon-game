using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float health;          // Santé actuelle
    public float maxHealth;       // Santé maximale
    public Image healthBar;       // Barre de santé
    public GameManagerScript gameManager; // Référence au GameManager
    private bool isDead = false;  // État pour éviter de relancer plusieurs fois Respawn()

    void Start()
    {
        maxHealth = health; // Initialise la santé maximale
        isDead = false;
    }

    void Update()
    {
        // Met à jour la barre de santé
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        // Si la santé tombe à 0 et que le joueur n'est pas encore marqué comme mort
        if (health <= 0 && !isDead)
        {
            isDead = true; // Marque le joueur comme mort pour éviter plusieurs appels
            Respawn(); // Réapparition au dernier checkpoint
        }
    }

    private void Respawn()
    {
        Debug.Log("Respawn au dernier checkpoint.");

        // Réinitialise la santé
        health = maxHealth;
        healthBar.fillAmount = 1;

        // Replace le joueur au dernier checkpoint
        Vector3 respawnPosition = gameManager.GetCheckpoint();
        if (respawnPosition != Vector3.zero)
        {
            transform.position = respawnPosition; // Réapparition au checkpoint
            Debug.Log("Réapparu au checkpoint : " + respawnPosition);
        }
        else
        {
            Debug.Log("Aucun checkpoint défini. Impossible de réapparaître.");
        }

        // Marque le joueur comme vivant pour pouvoir mourir à nouveau
        isDead = false;
    }
}
