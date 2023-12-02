using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Test"))
        {
            Debug.Log("Gracz wszedł w kontakt z przeszkodą!");
        }
    }
}