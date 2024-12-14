using UnityEngine;

public class CheckpointScript : MonoBehaviour
{

    public GameObject player;
    public Transform checkpoint;
    public GameManagerScript gameManager;
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.CompareTag("Player")){
            gameManager.SetCheckpoint(checkpoint.position);
            Debug.Log("Checkpoint reached");
            
        }
    }
}
