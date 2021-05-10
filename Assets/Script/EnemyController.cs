using UnityEngine;

/// <summary>
/// General class to control enemies
/// </summary>
public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip audioStep;
    private MeleeAttack meleeAtack;
    private int direction;
    private float timerPatrollingSide;
    private readonly float timePatrollingSide = 5;
    private AudioSource audioSource;
    private Transform heroTransform;
    private readonly float walkSpeed = 2;
    private readonly float runSpeed = 7;

    void Start()
    {
        heroTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        timerPatrollingSide = timePatrollingSide;
        direction = 1;
        meleeAtack = GetComponent<MeleeAttack>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 CoordinateDifference;
        CoordinateDifference = heroTransform.position - transform.position;
        timerPatrollingSide -= Time.deltaTime;

        // If the hero is less than 10 units from the enemy and the enemy
        // "sees" the hero. Enemy run to hero
        if (CoordinateDifference.magnitude < 10)
        {
            // If the hero is less than 10 units from the enemy. Enemy run to hero and attack
            if (CoordinateDifference.magnitude < 4) Attack(CoordinateDifference);
            else
            {
                if (((transform.localScale.x > 0) && (transform.position.x < heroTransform.transform.position.x)) ||
         ((transform.localScale.x < 0) && (transform.position.x > heroTransform.transform.position.x))) RunToHero(CoordinateDifference);
                // Enemies is less than 10 units and more than 4 units from the hero. But enemy don't "see" hero.
                else Patrolling();
            }
        }
        else Patrolling();
    }

    /// <summary>
    /// Method for movements enemies in a certain direction
    /// </summary>
    /// <param name="direction">Direction of movement of the enemy</param>
    private void Movement(float moveSpeed, int direction)
    {
        /*anim.SetBool("Walking", true);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioStep);
        }*/
        transform.position =
            transform.position + moveSpeed * new Vector3(direction, 0, 0) * Time.deltaTime;
    }

    private void Attack(Vector2 CoordinateDifference)
    {
        RunToHero(CoordinateDifference);
        meleeAtack.Attack();
    }

    /// <summary>
    /// Method of patrolling enemies. 
    /// </summary>
    private void Patrolling()
    {  
            anim.SetBool("Running", false);
            // Changing the side of patrol
            if (timerPatrollingSide < 0)
            {
                direction = direction * (-1);
                timerPatrollingSide = timePatrollingSide;
                transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
            }
            Movement(walkSpeed, direction);
    }

    /// <summary>
    /// Method tells enemies to run to hero
    /// </summary>
    /// <param name="coordinateDifference">Difference in coordinate between
    /// hero and enemy</param>
    private void RunToHero(Vector2 coordinateDifference)
    {
            // Which direction to run to the hero
            int dirRunning;
            if (coordinateDifference.x > 0)
                dirRunning = 1;
            else dirRunning = -1;

            transform.localScale = new Vector3(dirRunning, transform.localScale.y, transform.localScale.z);
            Movement(runSpeed, dirRunning);
            anim.SetBool("Running", true);
    }
}
