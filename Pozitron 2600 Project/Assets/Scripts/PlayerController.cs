using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;       // l/r speed
    [SerializeField] float height = -3.0f;     // how high the ship is

    public Transform bulletStart;
    public GameObject bullet;

    void Awake()
    {
        transform.position = new Vector3(0.0f, height, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        Shoot();
    }

    private void MovePlayer()
    {
        transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0.0f, 0.0f);    // move l/r

        if (transform.position.x > 7.2f)
        {
            transform.position = new Vector3(-7.19f, height, 0.0f);     // r->l screen move otherside thingy
        }
        else if (transform.position.x < -7.2)
        {
            transform.position = new Vector3(7.19f, height, 0.0f);      // l->r screen move otherside thingy
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("PewPew!");
            Instantiate(bullet, bulletStart.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
