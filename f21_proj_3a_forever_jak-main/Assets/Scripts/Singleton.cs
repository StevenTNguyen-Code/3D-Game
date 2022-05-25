using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
   //Intialize the Singleton instance
   public static Singleton Instance = null;

   //Initializing the variable character name. 
   //If player enters name, the value will change to 1
   public int bo_character_Name = 0;
    public Color32 color = Color.black;
  
   public void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
         DontDestroyOnLoad(gameObject);
      }
      else
      {
          Destroy(gameObject);
      }
   }
   
}
