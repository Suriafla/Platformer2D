using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    // public LayerMask enemies;
    // [SerializeField] private float radius;
    // public Transform backward;
   // public Transform forward;
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;
    private Transform characterTransform;

    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        characterTransform = GetComponent<Transform>();

    }


    void Update()
    {
        
    }

    public void Hurt(float direction)
    {
       /*
        Collider2D[] forwardSensor = Physics2D.OverlapCircleAll(forward.position, radius, enemies);
        Collider2D[] backwardSensor = Physics2D.OverlapCircleAll(backward.position, radius, enemies);

        if (rb && forwardSensor.Length > 0)
            rb.AddForce(new Vector2(-4f*characterTransform.localScale.x, 2f), ForceMode2D.Impulse);
        if (rb && backwardSensor.Length > 0)
            rb.AddForce(new Vector2(4f* characterTransform.localScale.x, 2f), ForceMode2D.Impulse);       
        if (anim) anim.SetTrigger("Hurt");        
        */
        if(rb) rb.AddForce(new Vector2(4f*direction, 2f), ForceMode2D.Impulse);
        if (anim) anim.SetTrigger("Hurt");
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(forward.position, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(backward.position, radius);
    }
    */
    
}
