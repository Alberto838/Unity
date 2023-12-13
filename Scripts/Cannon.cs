using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float frequency = 2;
    public float force = 1;
    public GameObject projectile;
    public Vector2 direction;
    public Transform origin;
    bool isActive = true;

    void Start()
    {
        StartCoroutine(ShootCycle());
    }

    IEnumerator ShootCycle() {
        while(isActive){
            yield return new WaitForSeconds(frequency);
            GameObject newProjectile = Instantiate(projectile, origin.position, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().Shoot(direction, force);
        }
    }
    
    void Update()
    {
        
    }
}
