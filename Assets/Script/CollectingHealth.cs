using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        HealthController collectingHealth = other.GetComponent<HealthController>();
        if ((collectingHealth != null) && (collectingHealth.CurrentHealth < collectingHealth.MaxHealth))
        {
            collectingHealth.HealthChange(1);
            Destroy(gameObject);
        }
    }
}
