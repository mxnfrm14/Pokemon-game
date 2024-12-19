using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    private static GameManagerScript instance;

    // Singleton pattern to ensure only one GameManager
    public static GameManagerScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManagerScript>();
                if (instance != null)
                {
                    DontDestroyOnLoad(instance.gameObject);
                }
            }
            return instance;
        }
    }

    void Start()
    {
        // Set Game Over UI to inactive at the start
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    public void gameOver()
    {
        // Show Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void restart()
    {
        // Optionally reset health here before restarting
        playerHealth.Instance.ResetHealthToDefault();
        
        // Reload the current scene when the player restarts
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quit()
    {
        Application.Quit();
    }
}
