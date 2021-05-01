using UnityEngine;

/// <summary>
/// Class to implement of ball movements
/// </summary>
public class MovementBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8;
    private Rigidbody2D rb;
    private Transform ballTransform;
    private int dirMoving = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Move(moveSpeed);
    }

    private void ChangeDirection()
    {
        dirMoving = (-1) * dirMoving;
    }

    /// <summary>
    /// Method to change direction of move, when ball collision with wall or player
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            ChangeDirection();
        }
    }

    /// <summary>
    /// Method to move ball
    /// </summary>
    /// <param name="moveSpeed">move speed of ball</param>
    private void Move(float moveSpeed)
    {
        rb.AddForce(new Vector2(dirMoving * moveSpeed, 0));
    }
}
