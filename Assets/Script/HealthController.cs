using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;   
    }


    void Update()
    {
        if((currentHealth <= 0)&&(this.gameObject.CompareTag("Enemy")))
        {
            Destroy(this.gameObject);
        }
    }

    public void HealthChange(int numberLives)
    {
        currentHealth = Mathf.Clamp(currentHealth + numberLives, 0, maxHealth);
        Debug.Log(currentHealth);
        Debug.Log(this.gameObject.name);
    }

}
