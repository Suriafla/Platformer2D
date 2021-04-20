using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;

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
