using UnityEngine;

public class AnimateTakingDamage : MonoBehaviour
{
    [SerializeField] private Animator anim;
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
        if (healthController.CurrentHealth < tempForHealth)
        {
            Hurt(0);
            tempForHealth = healthController.CurrentHealth;
        }
    }

    public void Hurt(float direction)
    {
        if(rb) rb.AddForce(new Vector2(4f*direction, 2f), ForceMode2D.Impulse);
        if (anim) anim.SetTrigger("Hurt");
    }
}
