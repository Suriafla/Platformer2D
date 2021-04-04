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
            Debug.Log("stay");
            takeDamage.Hurt();          
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        HealthController healthController = other.gameObject.GetComponent<HealthController>();
        if (healthController != null)
        {
            Debug.Log("exit");
            healthController.HealthChange(-1);
        }
    }

}
