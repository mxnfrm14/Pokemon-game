using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the inspector
    private GameObject player; // Reference to the player object

    void Start()
    {
        // Check if the player already exists (i.e., it was transferred from a previous scene)
        if (playerHealth.Instance != null && playerHealth.Instance.gameObject != null)
        {
            player = playerHealth.Instance.gameObject; // Reuse the existing player
            player.transform.position = transform.position; // Set the position where it should spawn
            player.transform.rotation = transform.rotation; // Set the rotation
        }
        else
        {
            // Instantiate the player prefab if it doesn't already exist
            player = Instantiate(playerPrefab, transform.position, transform.rotation);
            DontDestroyOnLoad(player); // Make sure the player persists between scenes

            // Set up the health of the newly instantiated player (optional)
            Unit playerUnit = player.GetComponent<Unit>();
            if (playerUnit != null)
            {
                playerUnit.currentHP = playerUnit.maxHP; // Set player health as per game logic
            }
            else
            {
                Debug.LogError("Player prefab does not have a Unit component.");
            }
        }

        // Ensure that the camera follows the correct player
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.player = player; // Set the camera to follow the newly instantiated or reused player
        }
        else
        {
            Debug.LogError("CameraFollow script not found on main camera.");
        }
    }
}
