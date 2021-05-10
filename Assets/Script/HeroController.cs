using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioLanding;
    [SerializeField] private AudioClip audioStep;
    public float BottomOfMap { get; } = 5;
    private bool standingOnGround;
    private MeleeAttack meleeAttack;
    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        meleeAttack = GetComponent<MeleeAttack>();
        standingOnGround = true;
    }

    private void FixedUpdate()
    {
        CheckStandingOnGround();
    }

    void Update()
    {

        if (standingOnGround)
        {
            animator.SetBool("isJump", false);
        }
        else
        {
            animator.SetBool("isRun", false);
            animator.SetBool("isJump", true);
        }

        if (Input.GetButtonDown("Fire1")) Attack();
        if (Input.GetButtonDown("Jump")) Jump();
        if (Input.GetAxisRaw("Horizontal") != 0.0f) Running();
        else animator.SetBool("isRun", false);

        // The fall of the player leads to a reload of the level
        if (transform.position.y < BottomOfMap)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("True");
        }

    }

    /// <summary>
    /// Method for Attack
    /// </summary>
    private void Attack()
    {
        meleeAttack.Attack();
    }

    /// <summary>
    /// Method to run the character when pressing the corresponding buttons
    /// </summary>
	private void Running()
	{   
		if (animator.GetBool("isJump") == false) animator.SetBool("isRun", true);
		if ((standingOnGround) && (!audioSource.isPlaying))
		{
			audioSource.PlayOneShot(audioStep);
		}

        transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), transform.localScale.y, transform.localScale.z);
        
		transform.position = 
			transform.position + moveSpeed * new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime;
	}

    /// <summary>
    /// Method to jump using "AddForce" from "Rigidbody2D"
    /// </summary>
	public void Jump()
	{
		if (standingOnGround)
		{
			rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
		}
	}

    /// <summary>
    /// Method for checking the location of the main character on the ground.
    /// If the circle centered at the hero's feet crosses more than one collider,
    /// then the hero is on the ground (the circle will always cross one
    /// collider - the hero's collider)
    /// </summary>
	private void CheckStandingOnGround()
	{
		Collider2D[] colider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
		if (colider.Length > 1) standingOnGround = true;
		else standingOnGround = false;
	}
}


