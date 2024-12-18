using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the inspector

    void Start()
    {
        if (playerHealth.Instance != null && playerPrefab != null)
        {
            // Instantiate the player at the spawn point
            GameObject player = Instantiate(playerPrefab, transform.position, transform.rotation);
            // Update the player health instance with the new player object
            playerHealth.Instance.transform.position = transform.position;
            playerHealth.Instance.transform.rotation = transform.rotation;

            Unit playerUnit = player.GetComponent<Unit>();
            if (playerUnit != null)
            {
                playerHealth.Instance.health = playerUnit.currentHP;
                playerHealth.Instance.maxHealth = playerUnit.maxHP;
            }
            else
            {
                Debug.LogError("Player prefab does not have a Unit component.");
            }
        }
        else
        {
            Debug.LogError("PlayerHealth instance or playerPrefab is not assigned.");
        }
    }
}