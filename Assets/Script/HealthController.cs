using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        if((currentHealth <= 0)&&(!this.gameObject.CompareTag("Player")))
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
