using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Person_Movement : MonoBehaviour
{
    //initializes the controller for the character
    public CharacterController controller;

    //handles the direction of the camera of where the character is heading
    public Transform cam;

    //initializes the speed
    public float speed = 6f;

    //initializes the smoothness of the character as it turns in the direction it wants
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    //Information to handle animation - Steven Nguyen. 
    public Animator animator;
    public float runSpeed = 10f; 
    float hMovement = 0f; //Handles the horizontal movement
    float vMovement = 0f; //Handles the vertical movement too. 
    bool jump = false; 


    // Update is called once per frame
    void Update()
    {
        //Takes the input of the axis
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //This handles the characters 360 degree movement
        //Also handles the characters movement as it turns 
        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime );
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }





    //Handles the character's movement animtaion scene
    /////////////////////////////////////////////////////////////////////////////////
      
       hMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
       vMovement = Input.GetAxisRaw("Vertical") * runSpeed; //Added by - Steven Nguyen

       animator.SetFloat("Speed", Mathf.Abs(hMovement + vMovement)); //Added + vMovement inside argument to make it so character's speed is not just horizontal but vertical as well - Steven Nguyen. 
       //animator.SetFloat ("Speed", Mathf.Abs(vMovement)); //This doesn't take into account the horizontal movement if added so leave commented - Steven Nguyen. 
      
       if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

       /*if(Input.GetButtonDown("Fire1"))
        {
        
            animator.SetBool("IsShooting", true);
            //SoundManagerScript.PlaySound ("Fire");
        } */ 

    /////////////////////////////////////////////////////////////////////////////////





    }

    //For when we land, we want our jump to be false to show we are no longer jumping. - Steven Nguyen 
    public void OnLanding()
    {
        animator.SetBool("IsJumping",false);
    }

    void FixedUpdate()
    {
        //controller.Move(hMovement * Time.fixedDeltaTime, false,jump);
        jump = false;
    }
    
}
