using UnityEngine;

/// <summary>
/// Class for starting the animation of taking damage
/// </summary>
public class AnimateTakingDamage : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private HealthController healthController;
    private int tempForHealth;
 
    void Start()
    {
        healthController = GetComponent<HealthController>();
        rb = GetComponent<Rigidbody2D>();
        tempForHealth = healthController.MaxHealth;
    }

    private void Update()
    {
        CheckTakingDamage();
    }

    /// <summary>
    /// Implementing the animation of receiving damage
    /// </summary>
    /// <param name="direction">direction of impulse force</param>
    public void TakeDamage(float direction)
    {
        if(rb) rb.AddForce(new Vector2(4f*direction, 2f), ForceMode2D.Impulse);
        if (animator) animator.SetTrigger("Hurt");
    }

    /// <summary>
    /// Check taking damage
    /// </summary>
    private void CheckTakingDamage()
    {
        if (healthController.CurrentHealth < tempForHealth)
        {
            TakeDamage(0);
            tempForHealth = healthController.CurrentHealth;
        }
    }
}
