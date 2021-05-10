using UnityEngine;

/// <summary>
/// Class for objects that deal damage when colliding with it
/// </summary>
public class DamageCollider : MonoBehaviour
{
    /// <summary>
    /// The method takes away one unit of health upon collision with an object
    /// </summary>
    /// <param name="other">Takes one life unit away from other.gameObject</param>
    private void Damage(Collision2D other)
    {
        HealthController healthController = other.gameObject.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.HealthChange(-1);
        }
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {
        Damage(other);
    }
}
