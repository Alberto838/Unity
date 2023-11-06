using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_1 : MonoBehaviour
{
    public float speed = 10.0f;      // Speed of object movement
    private bool move_right = true;  // Variable to control the direction of movement
    private Vector3 start_position;  // Initial position of the object
    private float distance = 0.0f;   // Distance traveled by the object

    void Start()
    {
        start_position = transform.position;
    }

    void Update()
    {
        if (move_right)
        {
            // Moving the object to the right (x-axis)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            distance += speed * Time.deltaTime;

            if (distance >= 10.0f)
            {
                move_right = false;
                distance = 0.0f;  // Reset the distance
            }
        }
        else
        {
            // Moving the object to the left (x-axis)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            distance += speed * Time.deltaTime;

            if (distance >= 10.0f) 
            {
                move_right = true;
                distance = 0.0f;
            }
        }
        
    }
}
