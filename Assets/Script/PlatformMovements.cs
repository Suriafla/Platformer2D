using UnityEngine;

/// <summary>
/// Class that implements the movements of platfrom
/// </summary>
public class PlatformMovements : MonoBehaviour
{
  
    private int dirMoving = 1;
    private readonly float moveSpeed = 5;

    void Update()
    {
        if (CompareTag("Platform"))
        {
            MoveHorizontal(moveSpeed);
        }
    }

    /// <summary>
    /// Change direction of movement when collision with player and move him
    /// along with platform.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            dirMoving = (-1) * dirMoving;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    /// <summary>
    /// Method for horizontal movement of platforms
    /// </summary>
    /// <param name="moveSpeed">Platform move speed</param>
    private void MoveHorizontal(float moveSpeed)
    {
        transform.position = transform.position + dirMoving * moveSpeed * new Vector3(-1, 0, 0) * Time.deltaTime;
    }

    /// <summary>
    /// Method for decoupling the coordinates of the hero from the coordinates of the platform
    /// </summary>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
