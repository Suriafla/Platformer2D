using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class to work with the enemy health panel
/// </summary>
public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    private HealthController healthController;

    private void Start()
    {
        healthController = GetComponent<HealthController>();
        SetMaxHealthBar(healthController.MaxHealth);
    }

    private void Update()
    {
        ChangeHealthBar(healthController.CurrentHealth);
    }

    /// <summary>
    /// Class to set absolut maximum value and maximum health for health bar
    /// on the Start
    /// </summary>
    /// <param name="maxHealth">Maximum enemies health</param>
    public void SetMaxHealthBar(int maxHealth)
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    /// <summary>
    /// Method to change the health bar according to the current health
    /// </summary>
    /// <param name="currentHealth">Current health of enemies</param>
    public void ChangeHealthBar(int currentHealth)
    {
        healthBar.value = currentHealth;
    }

}
