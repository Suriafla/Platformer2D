using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
   
    public AudioClip audioSwingWeapon;
    public AudioClip audioShot;
    public Transform center;
    public float periodAttack;

   // [SerializeField] private float rangeAttack = 3;
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

    // Update is called once per frame
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
                //StartCoroutine(AttackAnim());                  
            }
        }
    }

  /*
   private IEnumerator AttackAnim()
    {
        yield return new WaitForSeconds(0.5f);
        
       Collider2D[] enemiesInRangeAttack = Physics2D.OverlapCircleAll(center.position, rangeAttack);
        
        if (enemiesInRangeAttack.Length > 0)
        {
            for (int i = 0; i < enemiesInRangeAttack.Length; i++)
            {
                if (enemiesInRangeAttack[i].gameObject.CompareTag("Enemy") && this.gameObject.CompareTag("Player")
                    || enemiesInRangeAttack[i].gameObject.CompareTag("Player") && this.gameObject.CompareTag("Enemy"))
                {
                    if (enemiesInRangeAttack[i].gameObject != null)
                    {
                        audioSource.PlayOneShot(audioShot);
                       
                        heathController = enemiesInRangeAttack[i].GetComponent<HealthController>();
                             takeDamage = enemiesInRangeAttack[i].GetComponent<TakeDamage>();

                        if(heathController)
                            enemiesInRangeAttack[i].GetComponent<HealthController>().HealthChange(-1);
                        if(takeDamage)
                            enemiesInRangeAttack[i].GetComponent<TakeDamage>().Hurt();
                    }
                }
            }
        } 
    }
*/

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center.position, rangeAttack);
    }
    */

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        Debug.Log("Attacking" + isAttacking);

        /*AnimatorClipInfo[] stInfos = anim.GetCurrentAnimatorClipInfo(0);
        if (stInfos != null)
        {
            AnimationClip info = stInfos[0].clip;
            float lenght = info.length;
            Debug.Log("Длина" + lenght + info.name);
        }
        */


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
