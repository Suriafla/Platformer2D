using UnityEngine;

/// <summary>
/// Class to play the end of game
/// </summary>
public class EndGame : MonoBehaviour
{
    public GameObject hero;
    public GameObject lose;
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

    /// <summary>
    /// General method for all endings
    /// </summary>
    private void End(Collider2D collision)
    {
        GlobalKey.EscKeyEnable = false;
        Time.timeScale = 0f;
        Pause.PauseMenu.SetActive(true);
        hero.GetComponent<HeroController>().enabled = false;
    }

    /// <summary>
    /// Losing ending method
    /// </summary>
    private void LoseEnd()
    {
        if (hero.GetComponent<HealthController>().CurrentHealth <= 0)
        {
            End(null);
            lose.SetActive(true);
        }
    }

    private void WinEnd(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            End(collision);
            win.SetActive(true);
        }
    }

    /// <summary>
    /// Winning ending method, Method will work only if hero comes to the chest
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WinEnd(collision);
    }
}