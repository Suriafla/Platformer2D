using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private HealthController healthController;
    // Start is called before the first frame update
    void Start()
    {
        healthController = GameObject.FindWithTag("Player").GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(healthController.CurrentHealth <= 0)
        {
            Packages    
        }
    }
}
