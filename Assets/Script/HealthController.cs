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

    /// <summary>
    /// Method to change the current number of lives within certain limits
    /// </summary>
    /// <param name="numberLives"></param>
    public void HealthChange(int numberLives)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + numberLives, 0, MaxHealth);
    }

    /// <summary>
    /// Method 
    /// </summary>
    private void DieEnemy()
    {
        if(CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
