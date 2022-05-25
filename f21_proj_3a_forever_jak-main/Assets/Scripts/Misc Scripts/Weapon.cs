using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Youtube, Brackey
    //Initializes the variable to used for the weapon
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int damage = 10;
    public GameObject impactEffect;
    
    //If the fire button has been pressed, it will shoot
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    //This functions handles the shooting of the bullets
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
