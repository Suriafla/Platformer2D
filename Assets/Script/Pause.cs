using UnityEngine;

/// <summary>
/// Class to work with pauses
/// </summary>
public class Pause : MonoBehaviour
{
    [SerializeField] private AudioClip audioPause;
    private AudioSource audioSource;
    public static GameObject PauseMenu { get; set; }
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Panel it's background pause menu with all buttons
        PauseMenu = transform.Find("Panel").gameObject;
        PauseMenu.SetActive(false);
    }

    void Update()
    {
        if (GlobalKey.EscKeyEnable == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                audioSource.PlayOneShot(audioPause);
                if (isPaused)
                {
                    Resume();
                }
                else SetPause();
            }
        }
    }

    /// <summary>
    /// Class to resume the game
    /// </summary>
    private void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = true;
    }

    /// <summary>
    /// Class to set pause the game
    /// </summary>
    private void SetPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = false;
    }
}