using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private MeleeAttack meleeAtack;
    private int direction;
    private float timerPatrollingSide;
    private readonly float timePatrollingSide = 5;
    private AudioSource audioSource;
    private Transform heroTransform;
    private bool availability;
    private HealthController healthController;
    private HealthBarEnemy healtBar;


    public AudioClip audioStep;

    void Start()
    {
        heroTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        timerPatrollingSide = timePatrollingSide;
        direction = 1;
        meleeAtack = GetComponent<MeleeAttack>();
        audioSource = GetComponent<AudioSource>();
        availability = true;
        healthController = GetComponent<HealthController>();
        healtBar = GetComponent<HealthBarEnemy>();
        healtBar.SetMaxHealthBar(healthController.maxHealth);
    }


    void Update()
    {
        healtBar.ChangeHealthBar(healthController.currentHealth);
        timerPatrollingSide -= Time.deltaTime;
        Patrolling();
    }

    private void Movement(float moveSpeed, int direction)
    {
        anim.SetBool("Walking", true);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioStep);
        }


        transform.position =
            transform.position + moveSpeed * new Vector3(direction, 0, 0) * Time.deltaTime;
    }

    private void Patrolling()
    {
        Vector2 diffCoordinate;
        diffCoordinate = heroTransform.position - transform.position;

        if (diffCoordinate.magnitude < 4)
        {
            //anim.SetBool("Running", false);
            //anim.SetBool("Walking", false);
            RunToHero(diffCoordinate, true);
            meleeAtack.Attack();
            availability = false;
            
        }

        else availability = true;

        // Если герой находится меньше чем на 10 единиц от противника и противник "видит" героя.
        if ((diffCoordinate.magnitude < 10) &&
            ((transform.localScale.x > 0) && (transform.position.x < heroTransform.transform.position.x)) ||
            ((transform.localScale.x < 0) && (transform.position.x > heroTransform.transform.position.x))) 
                    RunToHero(diffCoordinate, availability);  
        
        
        else
        {
            anim.SetBool("Running", false);
            //Смена стороны патрулирования
            if (timerPatrollingSide < 0)
            {
                direction = direction * (-1);
                timerPatrollingSide = timePatrollingSide;
                transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);

            }
            Movement(2, direction);
        }
    }


    private void RunToHero(Vector2 diffCoordinate, bool availability)
    {
        if (availability)
        {
            //Расчёт направление бега за героем
            int dirRunning;
            if (diffCoordinate.x > 0)
                dirRunning = 1;
            else dirRunning = -1;

            transform.localScale = new Vector3(dirRunning, transform.localScale.y, transform.localScale.z);
            //transform.position = Vector2.Lerp(transform.position, heroTransform.position, Time.deltaTime);
            Movement(7, dirRunning);
            anim.SetBool("Running", true);
        }

    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NameWeap = " + collision.tag);
        if(collision.CompareTag("Weapon"))
        {
            Vector2 diffCoordinate;
            diffCoordinate = heroTransform.position - transform.position;
            RunToHero(diffCoordinate, true);
        }
    }*/

}
