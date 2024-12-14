using UnityEngine;

public class TakeHealth : MonoBehaviour
{
    public GameObject objectToDestroy; // Reference to the enemy GameObject
    public playerHealth pHealth;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Destroy(objectToDestroy);
            pHealth.health += 20;
            
        }
    }
}
