using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieGFX : MonoBehaviour
{

    //Youtube Brackley
    public AIPath aiPath;

    //This function handles the updated of the desired velocity of ai path 
    //to the player
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
           transform.localScale = new Vector3(1f, 1f, 1f); 
        }
    }
}
