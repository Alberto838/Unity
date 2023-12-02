using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private MovePlayer playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<MovePlayer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerControllerScript.Jump(playerControllerScript.jumpHeight * 3f);
        }
    }
}

