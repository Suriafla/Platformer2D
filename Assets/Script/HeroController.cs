using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioLanding;
    [SerializeField] private AudioClip audioStep;
	private bool standingOnGround;
	public bool alive;
    private HealthController healthController;
	private MeleeAttack meleeAttack;
	private Rigidbody2D rb;
	private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		meleeAttack = GetComponent<MeleeAttack>();
        healthController = GetComponent<HealthController>();
		standingOnGround = true;
		alive = true;
	}

	private void FixedUpdate()
	{
		CheckStandingOnGround();    
    }

	// Update is called once per frame
	void Update()
	{
		if (alive)
		{
			if (healthController.CurrentHealth == 0) Die();

			if (standingOnGround)
			{
				anim.SetBool("isJump", false);
			}
			else
			{
				anim.SetBool("isRun", false);
				anim.SetBool("isJump", true);
			}
		
			if (Input.GetButtonDown("Fire1")) meleeAttack.Attack();
			if (Input.GetButtonDown("Jump")) Jump();
            if (Input.GetAxisRaw("Horizontal") != 0.0f) Running();
            else anim.SetBool("isRun", false);

            // Падение игрока приводит к перезагрузке уровня
            if (transform.position.y < 5)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}

	private void Running()
	{
		if (anim.GetBool("isJump") == false) anim.SetBool("isRun", true);
		if (standingOnGround && !audioSource.isPlaying)
		{
			audioSource.PlayOneShot(audioStep);
		}

        transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), transform.localScale.y, transform.localScale.z);
        
		transform.position = 
			transform.position + moveSpeed * new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime;
	}

	private void Jump()
	{
		if (standingOnGround)
		{
			rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
		}
	}

	private void CheckStandingOnGround()
	{
		Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
		if (colider.Length > 1) standingOnGround = true;
		else standingOnGround = false;
	}


	private void Die()
	{
		alive = false;
		anim.SetTrigger("die");
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Platform"))
		{
			this.transform.SetParent(collision.transform);
		}

        if((collision.gameObject.CompareTag("Ground")) || (collision.gameObject.CompareTag("Platform")))
        {
            audioSource.PlayOneShot(audioLanding);
        }
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Platform"))
		{
			this.transform.parent = null;
		}
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.3f);
    }
}


