using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fall : MonoBehaviour
{
    
    //This function will activate if the player has fallen through the hole.
    //The playuer will be brought back to the beginning of the game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Falling")
        {
            SceneManager.LoadScene(0);
        }

    }
}
