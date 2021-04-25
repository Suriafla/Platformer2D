using UnityEngine;

public class MovementBall : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8;
    private Rigidbody2D rb;
    private Transform ballTransform;
    private int dirMoving = 1;

    // Start is called before the first frame update
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player"))
        {
            ChangeDirection();
        }
    }

    private void Move(float moveSpeed)
    {
        rb.AddForce(new Vector2(dirMoving * moveSpeed, 0));
    }
}
