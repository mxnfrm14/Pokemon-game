using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy; // Reference to the enemy GameObject
    public playerHealth pHealth;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Get player's position and weak spot's position
            float playerY = collision.transform.position.y;
            float weakSpotY = transform.position.y;

            // Check if the player is jumping on top of the enemy
            if (playerY > weakSpotY + 0.1f) // Add a small offset
            {
                // Destroy the enemy if the player is above
                Destroy(objectToDestroy);

            }
            else
            {
                // Deal damage to the player if colliding from the side
                pHealth.health -= 10;
            }
        }
    }
}
