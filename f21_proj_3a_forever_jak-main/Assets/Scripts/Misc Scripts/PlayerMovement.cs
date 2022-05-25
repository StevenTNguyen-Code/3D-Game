using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Heart Object
    public CharacterDatabase heartDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    
    
    //game objects
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    //variables
    float hMovement = 0f;
    
    bool jump = false;
    
    [SerializeField] private int gems = 0;
    [SerializeField] private TextMeshProUGUI gemText;

    
    public float maxHealth = 100f;
	public float currentHealth;
    public float pointIncreasePerSecond;

	public HealthBar healthBar;

    public GameObject deathEffect;

    
	// Start is called before the first frame update
    void Start()
    {
    	currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        pointIncreasePerSecond = 1f;

        if(!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateHeart(selectedOption);

        
    }



    //gets player input and converts into movement
    void Update()
    {
       currentHealth += pointIncreasePerSecond * (Time.deltaTime);
       healthBar.SetHealth(currentHealth);
       

       if(currentHealth > maxHealth)
       {
           currentHealth = 100;
       }
       if(currentHealth < 0)
       {
           currentHealth = 0;
       }

       
       
       hMovement = Input.GetAxisRaw("Horizontal") * runSpeed;

       animator.SetFloat("Speed", Mathf.Abs(hMovement));
      
      
       if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

       if(Input.GetButtonDown("Fire1"))
        {
        
            animator.SetBool("IsShooting", true);
            SoundManagerScript.PlaySound ("Fire");
        }
        

    }

    private void UpdateHeart(int selectedOption)
    {
        Character heart = heartDB.GetHeart(selectedOption);
        artworkSprite.sprite = heart.HeartSprite;


    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    
     public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        SceneManager.LoadScene(4);
    }

    //sets jumping to false
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsShooting", false);
    }

    //more player movement
    void FixedUpdate()
    {

        Jump();
        Shooting();
       
    }

    private void Jump()
    {
        controller.Move(hMovement * Time.fixedDeltaTime, false, jump);
        jump = false;
        
    }

    private void Shooting()
    {
        if(Input.GetButtonUp("Fire1")){
        
            animator.SetBool("IsShooting", false);
            
        }
    }

    
    //keeps track of gems collected in game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Credit")
        {
            SceneManager.LoadScene(2);
        }

          if (collision.tag == "Treasures")
        {
            Destroy(collision.gameObject);
            gems = gems + 1;
            gemText.text = gems.ToString();
            SoundManagerScript.PlaySound ("precursorOrb");
        }

         if (collision.tag == "Daxter")
        {
            SoundManagerScript.PlaySound ("DaxterQuote");
        }
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Zombie")
        {
    
            switch (GameValues.Difficulty)
            {
            case GameValues.Difficulties.Amateur:
                TakeDamage(5);
                break;
            case GameValues.Difficulties.Expert:
                TakeDamage(15);
                break;
            }
         }  
        if(other.gameObject.tag == "DeathFall")
        {
            SceneManager.LoadScene(4);
         }            
                   
    }
}