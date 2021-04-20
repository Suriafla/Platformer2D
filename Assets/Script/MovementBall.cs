using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBall : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Transform ballTransform;
    private CircleCollider2D ballCollider;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballTransform = GetComponent<Transform>();
        ballCollider = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(ballTransform.position.x * speed, 0));
    }

    private void ChangeDirection()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            ChangeDirection();
        }
    }

}
