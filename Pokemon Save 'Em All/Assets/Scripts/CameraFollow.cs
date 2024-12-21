using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float timeoffset;
    public Vector3 posOffset;

    private Vector3 velocity;
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeoffset);
        }
    }
}