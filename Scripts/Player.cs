using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    bool isReleased = false;
    public float speed = 2600;
    public float jumpHeight = 7;
    RaycastHit2D pHit;
    public LayerMask playerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }   

    void Update()
    {

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, rb.velocity.y);
        
        if (Input.GetAxisRaw("Jump") > 0 && isReleased) 
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            SoundManager.PlaySound("Jump");
            isReleased = false;
        }
        else if (!isReleased && Input.GetAxisRaw("Jump") < 1) {
            isReleased = true;
        }

        pHit = Physics2D.Linecast(transform.position, transform.position - Vector3.up, playerMask);
        if (pHit && pHit.transform.CompareTag("Enemy") && pHit.transform.GetComponent<Enemy>() != null){
            pHit.transform.GetComponent<Enemy>().Destroy();
            SoundManager.PlaySound("Hit");
        }

        if (Input.GetKeyUp(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }

    }

    public void Destroy() {
        Menu.ChangeScene(1);
    }

}
