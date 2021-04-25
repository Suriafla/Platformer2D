using UnityEngine;

public class DamageCollider : MonoBehaviour
{
   

   /* void OnCollisionStay2D(Collision2D other)
    {

        AnimateTakingDamage takeDamage = other.gameObject.GetComponent<AnimateTakingDamage>();
        
        if (takeDamage != null)
        {
            takeDamage.Hurt(0);          
        }
    }
    */
    
    void OnCollisionEnter2D(Collision2D other)
    {
        HealthController healthController = other.gameObject.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.HealthChange(-1);
        }
    }

}
