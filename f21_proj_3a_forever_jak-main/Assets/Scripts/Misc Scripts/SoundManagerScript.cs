using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    //initialize the variable to use for the audio clip
    public static AudioClip precursorOrbSound, FireSound, daxterSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        //Will load the audio clips
        precursorOrbSound = Resources.Load<AudioClip> ("precursorOrb");
        FireSound = Resources.Load<AudioClip> ("Fire");
        daxterSound = Resources.Load<AudioClip> ("DaxterQuote");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Using a switch case to check the player player has activated,
    // then will play the corresponding audio clip
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Fire":
                audioSrc.PlayOneShot (FireSound);
                break;
            case "precursorOrb":
                audioSrc.PlayOneShot (precursorOrbSound);
                break;
            case "DaxterQuote":
                audioSrc.PlayOneShot (daxterSound);
                break;   
        }
    }
}
