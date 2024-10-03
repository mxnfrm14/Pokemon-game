using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Combat : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Combat");
        }
    }
}
