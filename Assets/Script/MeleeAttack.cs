using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float periodAttack;
    [SerializeField] private AudioClip audioSwingWeapon;
    [SerializeField] private AudioClip audioShot;
    [SerializeField] private Animator anim;
    private float timer;
    private bool isAttacking;
    private HealthController heathController;
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
            isAttacking = true;
            timer = periodAttack;
           
            if (anim)
            {
                anim.SetTrigger("Attack");
                audioSource.PlayOneShot(audioSwingWeapon);                
            }
        }
    }

    private void AttackTrigger(Collider2D other)
    {
        audioSource.PlayOneShot(audioShot);

        heathController = other.GetComponent<HealthController>();

        if (heathController)
            other.GetComponent<HealthController>().HealthChange(-1);
        isAttacking = false;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Player")
            && (timer > 0) && (isAttacking == true))
        {
            AttackTrigger(other);
        }

        if(other.gameObject.CompareTag("Player") && this.gameObject.CompareTag("Enemy")
            && (timer > 0) && (isAttacking == true) && other.GetComponent<HeroController>().alive == true)
        {
            AttackTrigger(other);
        }
    }    
} 
