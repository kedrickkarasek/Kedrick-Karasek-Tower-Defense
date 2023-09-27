using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; //setting speed

    private Transform target;
    private int wavepointIndex = 0; //current waypoint index we are trying to reach

    private void Start()
    {
        target = Waypoints.points[0]; //setting target to first point
    }

    private void Update() //every frame we want to move a little closer to the waypoint
    {
        Vector3 direction = target.position - transform.position; //direction vector
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); //normalized to make sure it has a fixed speed, moving at a set speed not by framerate


        Quaternion rotation = Quaternion.LookRotation(direction); //source: https://www.youtube.com/watch?v=nJiFitClnKo
        transform.rotation = rotation;

        if(Vector3.Distance(transform.position, target.position) < 0.2f) //checking to see if we are close to waypoint if so get the next waypoint
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() //changing from one waypoint to another 
    {
        if(wavepointIndex >= Waypoints.points.Length - 1) //if the enemy reaches the end destory game object 
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

}
