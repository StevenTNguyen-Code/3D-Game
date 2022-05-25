using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Brackeys
    //These variable are used to hold the data for the bullet speed, damage and visual effect
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject impactEffect;


    //This method performs the velocity of the bullet
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    
    //On Trigger, once the bullet impacts the zombies, the zombie will take damage from the bullet
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Zombie zombie = hitInfo.GetComponent<Zombie>();
        if (zombie != null)
        {
            zombie.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        
        Destroy(gameObject);
    }

}
