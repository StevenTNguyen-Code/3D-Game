using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//System.Serializable allows us to view the variable in Unity inspector
[System.Serializable]
public class Character 
{
    //This intialize the ability to store the heart color, and inialize the sprite for the heart artwork
    public string heartName;
    public Sprite HeartSprite;
}
