using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameValues.Difficulty == GameValues.Difficulties.Amateur){
            //Debug.Log("Amateur");
            //Enemy.agent.speed
        } else {
            Debug.Log("Expert");
        }
    }

}
