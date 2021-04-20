using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float periodAttack;
    [SerializeField] private AudioClip audioSwingWeapon;
    [SerializeField] private AudioClip audioShot;
    [SerializeField] private Animator anim;
    private float timer;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;
    private HealthController heathController;
    private TakeDamage takeDamage; 
    private AudioSource audioSource;

    void Start()
    { 
        audioSource = GetComponent<AudioSource>();
        timer = 0;
        isAttacking = false;

    }

    void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Attack()
    {
        
        if (timer < 0)
        {
            Debug.Log("Can Attack" + anim.GetBool("Attack"));
            isAttacking = true;
            timer = periodAttack;
           
            if (anim)
            {
                anim.SetTrigger("Attack");
                audioSource.PlayOneShot(audioSwingWeapon);                
            }
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Player")
                   || other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Enemy")) && (timer > 0) && (isAttacking == true ))
        {
            audioSource.PlayOneShot(audioShot);

            heathController = other.GetComponent<HealthController>();
            takeDamage = other.GetComponent<TakeDamage>();

            if (heathController)
                other.GetComponent<HealthController>().HealthChange(-1);
            if (takeDamage)
                other.GetComponent<TakeDamage>().Hurt(transform.localScale.x);
            isAttacking = false;
        }        
    }    
} 
