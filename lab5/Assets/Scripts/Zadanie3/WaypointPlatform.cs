using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPlatform : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>(); 
    public float speed = 2.0f; 
    private int currentWaypointIndex = 0; 
    private bool movingForward = true; 

    void Update()
    {
        MovePlatform();

    void MovePlatform()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogWarning("Nie dodano punktów do ścieżki!");
            return;
        }

        Vector3 targetPosition = waypoints[currentWaypointIndex];
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (transform.position == targetPosition)
        {
            UpdateWaypoint();
        }
    }

    void UpdateWaypoint()
    {
        if (movingForward)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = waypoints.Count - 2;
                movingForward = false;
            }
        }
        else
        {
            currentWaypointIndex--;
            if (currentWaypointIndex < 0)
            {
                currentWaypointIndex = 1;
                movingForward = true;
            }
        }
    }

    public void AddWaypoint(Vector3 newWaypoint)
    {
        waypoints.Add(newWaypoint);
    }

    public void RemoveWaypoint(int index)
    {
        if (index >= 0 && index < waypoints.Count)
        {
            waypoints.RemoveAt(index);
        }
    }
}
