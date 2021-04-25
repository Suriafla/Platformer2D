using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get => maxHealth;}

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        DieEnemy();
    }

    public void HealthChange(int numberLives)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + numberLives, 0, MaxHealth);
    }

    private void DieEnemy()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
