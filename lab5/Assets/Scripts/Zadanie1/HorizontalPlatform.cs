using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
    public float speed = 2.0f;

    private Vector3 startPoint = new Vector3(0, 0, 0); // Ustawienie punktu startowego
    private Vector3 endPoint = new Vector3(5, 0, 0);   // Ustawienie punktu końcowego

    private bool playerOnPlatform = false;
    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = endPoint;
    }

    void Update()
    {
        if (playerOnPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentTarget) < 0.01f)
            {
                if (currentTarget == endPoint)
                    currentTarget = startPoint;
                else
                    currentTarget = endPoint;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            other.gameObject.transform.parent = null;
        }
    }
}