using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Load_Combat2 : MonoBehaviour
{
    public GameObject player;

    public GameManagerScript gameManager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Combat 1");
        }
    }
}

