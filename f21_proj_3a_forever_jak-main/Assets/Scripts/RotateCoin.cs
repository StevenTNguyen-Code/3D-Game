using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RotateCoin : MonoBehaviour
{
    //first frame update
    public int num;

    void Start()
    {
        num = Random.Range(0, 360);
        this.transform.Rotate(0, num, 0, Space.Self);
    }

    
}
