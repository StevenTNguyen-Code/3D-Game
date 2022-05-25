using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Singleton.Instance != null)
        {
            this.GetComponent<SpriteRenderer>().color = Singleton.Instance.color;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.black;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
