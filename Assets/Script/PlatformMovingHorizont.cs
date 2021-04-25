using UnityEngine;

public class PlatformMovingHorizont : MonoBehaviour
{
    private int dirMoving = 1;
    private readonly float moveSpeed = 5;

    void Update()
    {
        Move(moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            dirMoving = (-1) * dirMoving;
        }
    }

    private void Move(float moveSpeed)
    {
        transform.position = transform.position + dirMoving * moveSpeed * new Vector3(-1, 0, 0) * Time.deltaTime;
    }
}
