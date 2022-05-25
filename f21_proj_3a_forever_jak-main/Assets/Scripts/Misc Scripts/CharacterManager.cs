using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{


    //These are the variable we need to used to store the database for the heart,
    // name of the color, and rememeber the color we have choosen
    public CharacterDatabase heartDB;
    public Text nameText;
    public SpriteRenderer artworkSprite;
    public string heartinfo;
    private int selectedOption = 0;

    // Heart color will be loaded onto the game
    void Start()
    {
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

    //This gives the ability to click the next heart sprite 
    //once choosen, we are then given the ability to save that information
    //and carry it into the game
    public void NextOption()
    {
        selectedOption++;

        if(selectedOption >= heartDB.HeartCount)
        {
            selectedOption = 0;
        }

        UpdateHeart(selectedOption);
        Save();
    }


    //This gives the ability to click back button to chose the previous heart sprite 
    //once choosen, we are then given the ability to save that information
    //and carry it into the game
    public void BackOption()
    {
        selectedOption--;

        if(selectedOption < 0)
        {
            selectedOption = heartDB.HeartCount - 1;
        }

        UpdateHeart(selectedOption);
        Save();
    }

    //This updates the description of the heart color onto the screen
    private void UpdateHeart(int selectedOption)
    {
        Character heart = heartDB.GetHeart(selectedOption);
        artworkSprite.sprite = heart.HeartSprite;
        nameText.text = heart.heartName;
        //CreateUserInterface.gameCharacteristics.heart_color = heart.heartName;
        //Debug.Log(heart.heartName);
        //heartinfo = heart.heartName;

    }

    //This allows us to load the information into the game
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    //This saves the heart color we have choosen to be used later onto the game
    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

}
