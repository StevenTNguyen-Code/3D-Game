using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameValues
{
    //This initialize the difficulties modes
    public enum Difficulties {Amateur, Expert };

    //The game defaults to Amatur mode
    public static Difficulties Difficulty = Difficulties.Amateur;

}
