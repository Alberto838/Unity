using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float speed = 1300;
    public LayerMask filterEnemy;
    bool isChangeDirection = false;
    Rigidbody2D rb;
    RaycastHit2D hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int signDirection = Convert.ToInt32(isChangeDirection) - 1;
        float direction = Mathf.Sign(signDirection);
        rb.velocity = new Vector2(Time.deltaTime * speed * Mathf.Sign(signDirection), rb.velocity.y);

        hit = Physics2D.Linecast(transform.position, transform.position + Vector3.right * direction, filterEnemy);
        if(hit)
        {
            if(hit.transform.CompareTag("Player")){
                hit.transform.GetComponent<Player>().Destroy();
            } else{
            isChangeDirection = !isChangeDirection;
            }
        }

        hit = Physics2D.Linecast(transform.position, transform.position - Vector3.right * direction, filterEnemy);
        if(hit)
        {
            if(hit.transform.CompareTag("Player")){
                hit.transform.GetComponent<Player>().Destroy();
            }
        }
    }

    public void Destroy()
    {
        gameObject.SetActive(false);
    }
}
