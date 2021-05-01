using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class HeartsHUD responsible for the operation of the main character's life
/// panel
/// </summary>
public class HeartsHUD : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    private HealthController hero;

    void Start()
    {
        hero = GetComponent<HealthController>();
    }

    void Update()
    {
        HeartsFillControl(hero.MaxHealth);
    }

    /// <summary>
    /// Controls filling of hearts in accordance with the current number of 
    /// lives
    /// </summary>
    /// <param name="maxHearts">Used to determine the maximum number of hearts
    /// with which the method will work</param>
    private void HeartsFillControl(int maxHearts)
    {
        for (int i = 0; i < hero.CurrentHealth; i++)
        {
            // Turn on the filled heart sprite
            hearts[i].fillAmount = 1;
        }

        for (int j = hero.CurrentHealth; j < maxHearts; j++)
        {
            hearts[j].fillAmount = 0;
        }
    }
}
