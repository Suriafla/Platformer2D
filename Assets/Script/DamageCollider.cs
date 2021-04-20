using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
   

    void OnCollisionStay2D(Collision2D other)
    {

        TakeDamage takeDamage = other.gameObject.GetComponent<TakeDamage>();
        
        if (takeDamage != null)
        {
            takeDamage.Hurt(0);          
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        HealthController healthController = other.gameObject.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.HealthChange(-1);
        }
    }

}
