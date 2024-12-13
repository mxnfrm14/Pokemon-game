using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            // Check the current scene and load the next one
            if (currentScene == "Numero1")
            {
                SceneManager.LoadScene("Numero2");
            }
            else if (currentScene == "Numero2")
            {
                SceneManager.LoadScene("Numero3");
            }
        }
    }
}