using UnityEngine;

/// <summary>
/// Class to implement melee atack of units
/// </summary>
public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float periodAttack;
    [SerializeField] private AudioClip audioSwingWeapon;
    [SerializeField] private AudioClip audioShot;
    [SerializeField] private Animator anim;
    private float timer;
    private bool isAttacking;
    private HealthController healthController;
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

    /// <summary>
    /// Method to animate melee attack
    /// </summary>
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

    /// <summary>
    /// Reduced health when the weapon touch an object while attack
    /// </summary>
    /// <param name="other">this is the one who is attacked</param>
    private void AttackTrigger(Collider2D other)
    {
        audioSource.PlayOneShot(audioShot);

        healthController = other.GetComponent<HealthController>();

        if (healthController)
            other.GetComponent<HealthController>().HealthChange(-1);
        isAttacking = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Player")
            && (timer > 0) && (isAttacking == true))
        {
            AttackTrigger(other);
        }

        if(other.gameObject.CompareTag("Player") && gameObject.CompareTag("Enemy")
            && (timer > 0) && (isAttacking == true))
        {
            AttackTrigger(other);
        }
    }    
} 
