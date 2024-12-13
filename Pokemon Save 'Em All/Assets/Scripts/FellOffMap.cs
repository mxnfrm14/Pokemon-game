using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellOffMap : MonoBehaviour
{

    public GameObject player;
    public Transform RespawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.CompareTag("Player")){
            player.transform.position = RespawnPoint.position;
        }
    }
}
