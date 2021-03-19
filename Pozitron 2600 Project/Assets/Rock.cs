using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public enum RockType { Big, Medium, Small };
    public RockType rockType;                       // list rock types

    void Awake()
    {
        switch(rockType)
        {
            case RockType.Big:
                transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
                break;
            case RockType.Medium:
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case RockType.Small:
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
