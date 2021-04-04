using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public LayerMask enemies;
    [SerializeField] private float radius;
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;
    public Transform backward;
    public Transform forward;
    private Transform hero;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hero = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt()
    {

        Collider2D[] forwardSensor = Physics2D.OverlapCircleAll(forward.position, radius, enemies);
        Debug.Log("Длина право " + forwardSensor.Length);
        Collider2D[] backwardSensor = Physics2D.OverlapCircleAll(backward.position, radius, enemies);
        Debug.Log("Длина лево " + backwardSensor.Length);
        if (rb && forwardSensor.Length > 0) rb.AddForce(new Vector2(-4f*hero.localScale.x, 2f), ForceMode2D.Impulse);
        if (rb && backwardSensor.Length > 0) rb.AddForce(new Vector2(4f* hero.localScale.x, 2f), ForceMode2D.Impulse);
        // if (rb) rb.AddForce(new Vector2(4f, 2f), ForceMode2D.Impulse);
        if (anim) anim.SetTrigger("Hurt");        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(forward.position, radius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(backward.position, radius);
    }
    
}
