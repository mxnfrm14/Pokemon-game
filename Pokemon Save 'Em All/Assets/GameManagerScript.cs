using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;
    private Vector3 lastCheckpointPosition = Vector3.zero; // Position par défaut du dernier checkpoint

    public Transform Checkpoint;

    void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); // Désactive l'écran Game Over au début
        }
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        lastCheckpointPosition = checkpointPosition; // Sauvegarde la position du checkpoint
        Debug.Log("Checkpoint sauvegardé à : " + checkpointPosition);
    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpointPosition; // Retourne la position du dernier checkpoint
    }

    public void TpCheckPoint()
    {
        player.transform.position = Checkpoint.position; // Téléporte le joueur au dernier checkpoint
    }
    
    public void gameOver()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true); // Affiche l'écran Game Over
        }
    }
}
