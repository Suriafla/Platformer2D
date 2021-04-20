using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private Rigidbody2D rb;
    private Transform characterTransform;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterTransform = GetComponent<Transform>();
    }

    public void Hurt(float direction)
    {
        if(rb) rb.AddForce(new Vector2(4f*direction, 2f), ForceMode2D.Impulse);
        if (anim) anim.SetTrigger("Hurt");
    }
}
