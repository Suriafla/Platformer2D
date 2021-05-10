using UnityEngine;

/// <summary>
/// Class to collect health units
/// </summary>
public class CollectingHealth : MonoBehaviour
{
    /// <summary>
    /// The method restores health to the object that entered the trigger, and
    /// destroys health unit
    /// </summary>
    private void Collect(Collider2D other)
    {
        HealthController collectingHealth = other.GetComponent<HealthController>();
        if ((collectingHealth != null) && (collectingHealth.CurrentHealth < collectingHealth.MaxHealth))
        {
            collectingHealth.HealthChange(1);
            Destroy(gameObject);
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        Collect(other);
    }
}
