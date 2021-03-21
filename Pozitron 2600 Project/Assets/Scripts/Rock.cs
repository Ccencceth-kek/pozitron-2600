using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public enum RockType { Big, Medium, Small };
    public RockType rockType;                       // list rock types

    [SerializeField] float maxRotSpeed = 50.0f;
    [SerializeField] float minRotSpeed = 10.0f;
    [SerializeField] float minForce = 20f;
    [SerializeField] float maxForce = 40f;

    private float rotationSpeed = 0.0f;
    private float rotation = 0.0f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        switch(rockType) // scale rock according to size
        {
            case RockType.Big:
                transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);
                rb.mass = 20;
                break;
            case RockType.Medium:
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                rb.mass = 10;
                break;
            case RockType.Small:
                transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                rb.mass = 5;
                break;
        }

        rotationSpeed = Random.Range(minRotSpeed, maxRotSpeed);

        if (Random.Range(1, 3) == 1)
        {
            rotationSpeed *= -1;
        }

        Vector2 force = new Vector2();
        force.x = Random.Range(minForce, maxForce);
        force.y = Random.Range(minForce, maxForce);

        if (Random.Range(1, 3) == 1)
        {
            force.x *= -1;
        }
        if (Random.Range(1, 3) == 1)
        {
            force.y *= -1;
        }

        rb.AddForce(force);
    }

    // Update is called once per frame
    void Update()
    {
        rotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation);

        if(transform.position.y < -3)
        {
            rb.AddForce(new Vector2(0.0f, 1f));
        }
    }
}
