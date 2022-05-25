using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I created a database for the heart artwork.
//This will allow us to be able to stored the heart sprite and gives us the ability to
// choose which heart sprite we would like ontop of our heartbar.
//Then it will return the index of the heart sprite we have choosen to the heart bar.
[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] heart;

    public int HeartCount
    {
        get
        {
            return heart.Length;
        }
    }

    public Character GetHeart(int index)
    {
        return heart[index];
    }
}
