using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroController : MonoBehaviour
{
		
	public int maxHealth = 100;
	public int currentHealth;
	public float lives = 5;
	public float moveSpeed = 10f;
	public float jumpPower = 13f;
	public AudioSource audioSource;
	public AudioClip audioStep;
	public AudioClip audioLanding;

	private Animator anim;
	private bool standingOnGround;
	private bool alive;
	private Rigidbody2D rb;
	private MeleeAttack heroAttack;

	private void Start()
	{
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		heroAttack = GetComponent<MeleeAttack>();


		standingOnGround = true;
		currentHealth = maxHealth;
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

			if (currentHealth == 0) Die();

			if (standingOnGround)
			{
				anim.SetBool("isJump", false);
			}
			else
			{
				anim.SetBool("isRun", false);
				anim.SetBool("isJump", true);
			}

			
			if (Input.GetButtonDown("Fire1")) Attack();
			if (Input.GetButtonDown("Jump")) Jump();
			if (Input.GetAxisRaw("Horizontal") != 0.0f) Running();
			else anim.SetBool("isRun", false);

			// Падение игрока приводит к перезагрузке уровня
			if (transform.position.y < 16)
			{

				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

			
			

			//if (Input.GetAxisRaw("Horizontal") < 0)
			//{
			//    transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;
			//}
			//if (Input.GetAxisRaw("Horizontal") > 0)
			//{
			//    Vector3 directionMoving = Vector3.right * Input.GetAxis("Horizontal");
			//    transform.position = Vector3.MoveTowards(transform.position, transform.position + directionMoving, moveSpeed * Time.deltaTime);
			//}

		}
	}

	private void Running()
	{
		if (anim.GetBool("isJump") == false) anim.SetBool("isRun", true);
		if (standingOnGround && !audioSource.isPlaying)
		{
			audioSource.PlayOneShot(audioStep);
		}

		transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
		transform.position = 
			transform.position + moveSpeed * new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime;

	}



	private void ResetAnimation()
	{
		anim.SetBool("isLookUp", false);
		anim.SetBool("isRun", false);
		anim.SetBool("isJump", false);
	}

	private void Jump()
	{
		Debug.Log(standingOnGround);
		if (standingOnGround)
		{
			rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
		}

	}

	private void Attack()
	{ 
		heroAttack.Attack();
	}

	private void CheckStandingOnGround()
	{
		Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
		// Условие первого приземление игрока
		if ((colider.Length > 1) && standingOnGround == false) audioSource.PlayOneShot(audioLanding);
		if (colider.Length > 1) standingOnGround = true;
		else standingOnGround = false;
	}

	/*public void HealthChange(int numberLives)
	{
		currentHealth = Mathf.Clamp(currentHealth + numberLives, 0, maxHealth);
		Debug.Log(currentHealth);
	} */

	/*public void Hurt()
	{
		anim.SetTrigger("hurt");
		rb.AddForce(new Vector2(-4f, 2f), ForceMode2D.Impulse);
	} */

	private void Die()
	{
		alive = false;
		anim.SetTrigger("die");
		// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Platform"))
		{
			this.transform.SetParent(collision.transform);
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Platform"))
		{
			this.transform.parent = null;
		}
	}
}


