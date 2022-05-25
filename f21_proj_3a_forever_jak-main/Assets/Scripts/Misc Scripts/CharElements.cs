using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharElements : MonoBehaviour
{
   
   //In order to protect the variables, we must contain it in a protected class

   protected class CharacterData
   {
        //Varibles that store the informations about the Character's Name
        public string character_Name;

   }
   protected class GameData{

         //variable to store game difficulty data (to be outputted in JSON)
        public string difficulty;
        public string heart_color;
   }
}
