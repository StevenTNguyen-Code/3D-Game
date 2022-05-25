using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int IsWalkingHash; //For Walking Animation
    int IsRunningHash; //For Running Animation

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("IsWalking");   
        IsRunningHash = Animator.StringToHash("IsRunning"); 
         
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bool IsWalking = animator.GetBool(IsWalkingHash); 
        bool IsRunning = animator.GetBool(IsRunningHash);
        bool forwardPressed = Input.GetKey("w"); //This will help us walk. 
        bool runPressed = Input.GetKey("left shift"); //This will help us activate running when walking. 



        //THIS AREA HANDLES THE WALKING ASPECT FOR JAK!
        //THIS IS THE CASE WHERE IDLE --> WALKING!!!!
        //This helps Jak start walking when the "w" key is pressed and he currently is not walking. 
        if(!IsWalking && forwardPressed)// || Input.GetKey("a")  || Input.GetKey("s") || Input.GetKey("d")) This does not work. Only 1 key can be pressed to walk so only go forward. 
        {
            //Sets the isRunning parameter to true, causing the running animation to start. 
            animator.SetBool(IsWalkingHash,true); 
        }

        //If Jak is walking and then all of the a sudden the "w" key is not pressed, he will stop walking. 
        if(IsWalking && !forwardPressed)
        {
            animator.SetBool(IsWalkingHash,false);
        }

        //THIS AREA HANDLES THE RUNNING ASPECT FOR JAK!
        //THIS IS THE CASE WHERE WALKING --> RUNNING!!!!
        //If Jak is currently not running and the "w" key and the "left shift" button are pressed, this will allow Jak to start running. 
        if(!IsRunning && (forwardPressed && runPressed))
        {
            //Sets the parameter of IsRunning to be true to enter this state of running. 
            animator.SetBool(IsRunningHash,true); 
        }

        //If Jak is currently running and the user stops pressing the "w" key and the "left shift" key, then he will stop running. 
        if(IsRunning && (!forwardPressed || !runPressed))
        {
            //Sets the parameter of IsRunning to be true to enter this state of running. 
            animator.SetBool(IsRunningHash,false); 
        }

        

       

        

       

        


    }
}
