using System.Collections;
using System.Collections.Generic;
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
        if((CurrentHealth <= 0)&&(this.gameObject.CompareTag("Enemy")))
        {
            Destroy(this.gameObject);
        }
    }

    public void HealthChange(int numberLives)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + numberLives, 0, MaxHealth);
        Debug.Log(CurrentHealth);
        Debug.Log(this.gameObject.name);
    }

}
