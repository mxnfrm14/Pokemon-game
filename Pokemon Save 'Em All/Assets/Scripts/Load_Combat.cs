using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Combat : MonoBehaviour
{
    public GameObject player;

    public GameManagerScript gameManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Combat");
        }
    }
}
