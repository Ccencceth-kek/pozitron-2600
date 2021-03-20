using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public enum RockType { Big, Medium, Small };
    public RockType rockType;                       // list rock types

    [SerializeField] float maxRotSpeed = 50.0f;
    [SerializeField] float minRotSpeed = 10.0f;

    private float rotationSpeed = 0.0f;
    private float rotation = 0.0f;

    void Awake()
    {
        switch(rockType) // scale rock according to size
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

        rotationSpeed = Random.Range(minRotSpeed, maxRotSpeed);

        if (Random.Range(1, 3) == 1)
        {
            rotationSpeed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);
    }
}
