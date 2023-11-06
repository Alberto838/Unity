using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_3 : MonoBehaviour
{
    public float speed = 5.0f; 
    public float rotation_angle = 90.0f; 

    private Vector3[] waypoints;
    private int waypoint_idx = 0; 

    void Start()
    {
        waypoints = new Vector3[4];
        waypoints[0] = transform.position + Vector3.right * 10;
        waypoints[1] = waypoints[0] + Vector3.forward * 10; 
        waypoints[2] = waypoints[1] - Vector3.right * 10; 
        waypoints[3] = waypoints[2] - Vector3.forward * 10; 
    }

    void Update()
    {
        // Check if the object has reached the current waypoint
        if (Vector3.Distance(transform.position, waypoints[waypoint_idx]) < 0.1f)
        {
            // If it has, move to the next waypoint and rotate the object
            waypoint_idx = (waypoint_idx + 1) % waypoints.Length;
            transform.Rotate(Vector3.up, rotation_angle);
        }

        // Move the object toward the current waypoint at the specified speed
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypoint_idx], speed * Time.deltaTime);
    }
}
