using UnityEngine;

public class TakeHealth : MonoBehaviour
{
    public GameObject objectToDestroy; // Reference to the health pack GameObject
    public AudioManager audiomanager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Play the health pack sound
            audiomanager.PlaySfxDegats(audiomanager.health);

            // Destroy the health pack object
            Destroy(objectToDestroy);

            // Ensure playerHealth.Instance is not null
            if (playerHealth.Instance != null)
            {
                // Increase the player's health
                playerHealth.Instance.health += 20;

                // Ensure health doesn't exceed the max health
                if (playerHealth.Instance.health > playerHealth.Instance.maxHealth)
                {
                    playerHealth.Instance.health = playerHealth.Instance.maxHealth;
                }

                // Update the health UI
                playerHealth.Instance.UpdateHealth(playerHealth.Instance.health);
            }
            else
            {
                Debug.LogWarning("PlayerHealth instance is not found.");
            }
        }
    }
}
