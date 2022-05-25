using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinIncrement : MonoBehaviour
{

    public Text textCoins;
    public int coinnum;
    public AudioSource coinsound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Coin")
        {
            coinnum++;
            textCoins.text = coinnum.ToString();
            coinsound.Play();
            Destroy(other.gameObject);
        }

    }
}
