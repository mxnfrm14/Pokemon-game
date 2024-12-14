using UnityEngine;

public class TakeHealth : MonoBehaviour
{
    public GameObject objectToDestroy; // Reference to the enemy GameObject
    public playerHealth pHealth;
    public AudioManager audiomanager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audiomanager.PlaySfxDegats(audiomanager.health);

            Destroy(objectToDestroy);
            pHealth.health += 20;
            
        }
    }
}
