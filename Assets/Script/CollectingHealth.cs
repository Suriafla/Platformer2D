using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingHealth : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        HealthController collectingHealth = other.GetComponent<HealthController>();
        if ((collectingHealth != null) && (collectingHealth.currentHealth < collectingHealth.maxHealth))
        {
            collectingHealth.HealthChange(1);
            Destroy(gameObject);
        }
        Debug.Log("Object that entered the trigger : " + other);


    }
}
