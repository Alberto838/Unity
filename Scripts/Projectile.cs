using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot(Vector2 direction, float force) {
        if(rb == null) {
            Start();
        }
        rb.AddForce(direction * force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.transform.CompareTag("Player")){
            collision.transform.GetComponent<Player>().Destroy();
        }
        gameObject.SetActive(false);
    }
   
}
