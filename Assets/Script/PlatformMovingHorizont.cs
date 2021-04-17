using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovingHorizont : MonoBehaviour
{
    private bool movingRight;
    private float speed = 5;

    void Start()
    {
        movingRight = true;
    }

    void Update()
    {
        transform.position = transform.position + speed * new Vector3(-1, 0, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (movingRight)
            {
                movingRight = false;
                speed = (-1) * speed;
            }

            else
            {
                movingRight = true;
                speed = (-1) * speed;
            }
        }
    }
}
