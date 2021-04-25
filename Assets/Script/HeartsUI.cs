using UnityEngine;
using UnityEngine.UI;

public class HeartsUI : MonoBehaviour
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

    private void HeartsFillControl(int maxHearts)
    {
        for (int i = 0; i < hero.CurrentHealth; i++)
        {
            // Включаем спрайт заполненного сердца
            hearts[i].fillAmount = 1;
        }

        for (int j = hero.CurrentHealth; j < maxHearts; j++)
        {
            hearts[j].fillAmount = 0;
        }
    }
}
