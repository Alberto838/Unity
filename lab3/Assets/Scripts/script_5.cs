using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_5 : MonoBehaviour
{
    public GameObject cube_prefab;      // Reference to the cube Prefab to be spawned
    public int number_of_cubes = 10;
    public int plane_size = 10; 
    public float spawn_interval = 1.0f; // Time interval between cube spawns

    private int spawned_cubes = 0;
    private List<Vector3> used_positions = new List<Vector3>();  // List to store positions of spawned cubes

    void Start()
    {
        // Invoke the "SpawnCube" method repeatedly with a specified time delay
        InvokeRepeating("SpawnCube", 0.0f, spawn_interval);  
    }

    void SpawnCube()
    {
        if (spawned_cubes < number_of_cubes)
        {
            Vector3 random_position;
            bool found_position = false;

            int count = 0;
            do
            {
                // Generate a random position within the specified plane size
                float randomX = Random.Range(-plane_size / 2, plane_size / 2);
                float randomZ = Random.Range(-plane_size / 2, plane_size / 2);
                random_position = new Vector3(randomX, 0.5f, randomZ);
                found_position = IsPositionAvailable(random_position);
                count++;
            } while (!found_position && count < 30);  // Try to find an available position, but avoid an infinite loop

            if (found_position)
            {
                used_positions.Add(random_position);
                Instantiate(cube_prefab, random_position, Quaternion.identity);
                spawned_cubes++;
            }
            else
            {
                Debug.LogWarning("Unable to find an available position.");
            }
        }
        else
        {
            // If all cubes have been spawned, cancel the repeating method invocation
            CancelInvoke("SpawnCube");
        }
    }

    bool IsPositionAvailable(Vector3 position)
    {
        if (used_positions.Count == 0)
        {
            return true; 
        }

        foreach (Vector3 used_position in used_positions)
        {
            // If the position is too close to a used position, it's not available
            if (Vector3.Distance(position, used_position) < 1.0f)
            {
                return false; 
            }
        }

        return true; // If no conflicts were found, the position is available
    }
}
