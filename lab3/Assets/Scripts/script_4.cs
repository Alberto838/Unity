using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_4 : MonoBehaviour
{
    public float speed = 5.0f;
    void Start() {}
    void Update()
    {
        // Get horizontal and vertical input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        // Calculate the movement vector based on input and speed
        Vector3 move = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        // Move the player object
        transform.Translate(move);
        
    }
}
