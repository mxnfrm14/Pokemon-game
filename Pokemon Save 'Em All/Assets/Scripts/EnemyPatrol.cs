using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;


    public SpriteRenderer graphics;
    private Transform targetWaypoint;
    private int destPoint = 0;
    void Start()
    {
        targetWaypoint = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = targetWaypoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        //si l'ennemi est quasi arrivé à sa destination
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            targetWaypoint = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
}
