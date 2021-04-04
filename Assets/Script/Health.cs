using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image[] heartFill;
    private HealthController hero;
    private int amount;

    // Start is called before the first frame update
    void Start()
    {
        hero = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
         
            
             for (int i = 0; i < hero.currentHealth; i++)
             {
                // Включаем спрайт заполненного сердца
                heartFill[i].fillAmount = 1;        
             }
            
             for(int j = hero.currentHealth; j < hero.maxHealth; j++)
            {
                heartFill[j].fillAmount = 0;
            }
             
    }
}
