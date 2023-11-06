using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_6 : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    // Math.Lerp
    // public Transform target; 
    // public float lerpSpeed = 0.5f;

    // void Update()
    // {
    //     Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
    //     transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    // }
}
