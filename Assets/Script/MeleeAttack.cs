using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
   
    public AudioClip audioSwingWeapon;
    public AudioClip audioShot;
    public AudioSource audioSource;
    public Transform center;

    [SerializeField] private float rangeAttack = 3;
    [SerializeField] private Animator anim;
    private float timer;
    private float periodAttack = 0.5f;
    private SpriteRenderer spriteRenderer;
    private bool isAttacking;
    private HealthController heathController;
    private TakeDamage takeDamage;

    // Start is called before the first frame update
    void Start()
    {
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
            timer = periodAttack;

            if (anim)
            {
                anim.SetTrigger("Attack");
                audioSource.PlayOneShot(audioSwingWeapon);
                StartCoroutine(AttackAnim());   
            }
        }
    }

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
                        /* spriteRenderer = enemiesInRangeAttack[i].GetComponent<SpriteRenderer>();
                         spriteRenderer.color = new Vector4(1, 
                             Mathf.Clamp(spriteRenderer.color.g - 0.2f, 0f, 1f),
                             Mathf.Clamp(spriteRenderer.color.b - 0.2f, 0f, 1f),
                             1);     */
                        heathController = GetComponent<HealthController>();
                             takeDamage = GetComponent<TakeDamage>();

                        if(heathController)
                            enemiesInRangeAttack[i].GetComponent<HealthController>().HealthChange(-1);
                        if(takeDamage)
                            enemiesInRangeAttack[i].GetComponent<TakeDamage>().Hurt();
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(center.position, rangeAttack);
    }
} 
