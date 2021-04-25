using UnityEngine;
using UnityEngine.UI;


public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;
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

    public void SetMaxHealthBar(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    
    public void ChangeHealthBar(int currentHealth)
    {
        slider.value = currentHealth;
    }

}
