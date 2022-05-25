using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    //Intializes the variable used for the zombies
    public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;
    public GameObject deathEffect;

    // Depending on what the player has choosen for the difficulty level, 
    // the corresponding difficulty level will activate the preset health life.
    //Updates the zombie health onto their health bar

    void Start()
    {
		
        switch (GameValues.Difficulty)
        {
            case GameValues.Difficulties.Amateur:
                maxHealth = 100;
                break;
            case GameValues.Difficulties.Expert:
                maxHealth= 500;
                break;
        }

        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        
    }
    
    //This function handles the damage of the zombies life
    //If the zombie life is 0, the zombie will die
    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }


    //This function handles the life of the zombie.
    //If it dies, the game will activate the death effect and destroy the game object of
    //the zombie that just died
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }    
}
