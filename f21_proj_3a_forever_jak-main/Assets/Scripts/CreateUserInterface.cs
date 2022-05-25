using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
 
public class CreateUserInterface : CharElements
{

    //These Variables are objects that stores the information about the characters data that can be referenced in Unity
    CharacterData playerUniqueCharacteristics = new CharacterData();
    GameData gameCharacteristics = new GameData();
    CharacterManager manager = new CharacterManager();


    
    //JSON - stores the content of the character's information
       
   
    public Text textOutputJson;

    //This method starts the the game
    //textOutputWalkingSpeed, textOutputRunningSpeed, textOutputJumpHeightSpeed & textOutputJson updates the slider in real time
    void Start()
    {
        textOutputJson = GameObject.Find("Output_JSON").GetComponent<Text>();
       
        
        
    }

   

///////////////////////////////////////////////////////////////////////////////////////////////////

    //Character's Name, Race, Class and Alignment (Functions)


    //once the user inputs a name it is store in this method - character name
    public void characterNameOnValueChanged(string playerName)
    {

        playerUniqueCharacteristics.character_Name = playerName;
        Debug.Log("character_Name = " + playerUniqueCharacteristics.character_Name);
        
        if(playerUniqueCharacteristics.character_Name.Length >= 1)
        {
            Singleton.Instance.bo_character_Name++;
        }
        if(Singleton.Instance.bo_character_Name == 0)
        {
            Destroy(gameObject);
        }
        
    }


///////////////////////////////////////////////////////////////////////////////////////////////////

    //Gives the ability for the user to exit the program
    public void quitButton()
	{
        Debug.Log("QUIT");
#if UNITY_EDITOR    
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif        
	}

///////////////////////////////////////////////////////////////////////////////////////////////////

    //This function gives the user the ability to save their inputs into a JSON Text
    public void jsonCreate()
    {

        if (GameValues.Difficulty != GameValues.Difficulties.Expert){
            gameCharacteristics.difficulty = "Amateur";
        }
        if (GameValues.Difficulty == GameValues.Difficulties.Expert){
            gameCharacteristics.difficulty = "Expert";
        }
        gameCharacteristics.heart_color = "Blue";
        //TODO: Get heart color to work properly

        //gameCharacteristics.heart_color = manager.heartinfo;
        Debug.Log(manager.heartinfo);


        string json = JsonUtility.ToJson(playerUniqueCharacteristics);
        Debug.Log(json);
        //player data

        textOutputJson.text = json +"\n";

        json = JsonUtility.ToJson(gameCharacteristics);
        Debug.Log(json);
        //game data

        textOutputJson.text += json;
       
    }

    // This method copy the content from JsonCreate which all anyone to copy the text to any external text editor
    //.Copy() copies from jsonText.text
    public void copyJson()
    {
        TextEditor jsonText = new TextEditor();
        jsonText.text = textOutputJson.text;
        jsonText.SelectAll();
        jsonText.Copy();            
    }

    //sets spawn color
    public void setColorRed()
    {
        Singleton.Instance.color = new Color32(140, 5, 18, 255);
    }
    public void setColorBlue()
    {
        Singleton.Instance.color = new Color32(22, 72, 230, 255);
    }
    public void setColorGreen()
    {
        Singleton.Instance.color = new Color32(47, 137, 13, 255);
    }
    public void setColorYellow()
    {
        Singleton.Instance.color = Color.yellow;
    }


}
