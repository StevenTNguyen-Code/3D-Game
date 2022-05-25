using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCoinSound : MonoBehaviour
{
    public AudioSource coinsound;

    public void playSoundEffect()
    {
        coinsound.Play();
    }
}
