using UnityEngine;

public class FellOffMap : MonoBehaviour
{
    public Transform respawnPoint;
    public AudioManager audioManager;

    private playerHealth pHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Find the playerHealth instance
        pHealth = playerHealth.Instance;

        // Optionally, find the respawn point if not assigned
        if (respawnPoint == null)
        {
            respawnPoint = GameObject.Find("RespawnPoint").transform;
        }

        if (audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (audioManager != null)
            {
                audioManager.PlaySfxDegats(audioManager.degats);
            }

            if (pHealth != null)
            {
                pHealth.UpdateHealth(pHealth.health - 10);
            }

            if (other.gameObject != null && respawnPoint != null)
            {
                other.gameObject.transform.position = respawnPoint.position;
            }
        }
    }
}