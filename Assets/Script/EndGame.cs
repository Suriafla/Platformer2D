using UnityEngine;

public class EndGame : MonoBehaviour
{
    private GameObject hero;
    private GameObject lose;
    private GameObject win;

    private void Start()
    {
        win = Pause.PauseMenu.transform.Find("Win").gameObject;
        lose = Pause.PauseMenu.transform.Find("Lose").gameObject;
        hero = GameObject.Find("Hero");      
        win.SetActive(false);
        lose.SetActive(false);
    }

    private void Update()
    {
        LoseEnd();
    }

    private void End(Collider2D collision)
    {
        GlobalKey.EscKeyEnable = false;
        Time.timeScale = 0f;
        Pause.PauseMenu.SetActive(true);
        hero.GetComponent<HeroController>().enabled = false;
    }

    private void LoseEnd()
    {
        if(hero.GetComponent<HealthController>().CurrentHealth <= 0)
        {
            End(null);
            lose.SetActive(true);         
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            End(collision);
            win.SetActive(true);
        }
    }
}