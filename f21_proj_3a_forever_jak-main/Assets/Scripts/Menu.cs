using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public partial class Menu : MonoBehaviour 
{
 
    public GameObject DifficultyToggles;

    //start button
    public void startButton()
	{
         
        //Inorder for the game to process, the player must have inputted their name
        if(Singleton.Instance.bo_character_Name != 0)
        {

            SceneManager.LoadScene(4);

            DifficultyToggles.transform.GetChild((int)GameValues.Difficulty).GetComponent<Toggle>().isOn = true;
            
        }
        else
        {
            SceneManager.LoadScene(0);
        }

	}
    

    //create character button
    public void createRollCharacter()
	{
        SceneManager.LoadScene(1);
	}

    public void instructions()
	{
        SceneManager.LoadScene(5);
	}


    //quit button
    public void quitButton()
	{
        Debug.Log("QUIT");
#if UNITY_EDITOR    
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif        
	}

    //back button 
    public void backButton()
    {
        SceneManager.LoadScene(0);
    }

    //Heart Color button 
    public void HeartColorButton()
    {
        SceneManager.LoadScene(3);
    }

    //This checks whether Amateur or Expert has been click,
    //then will set that difficulty onto the game
    #region Difficulty
    public void SetAmateurDifficulty(bool isOn)
    {
        if (isOn)
        {
            GameValues.Difficulty = GameValues.Difficulties.Amateur;
        }

    }
    public void SetExpertDifficulty(bool isOn)
    {
        if (isOn)
        {
            GameValues.Difficulty = GameValues.Difficulties.Expert;
        }
        
    }

    #endregion


}