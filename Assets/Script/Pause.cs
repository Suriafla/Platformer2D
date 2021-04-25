using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private AudioClip audioPause;
    private AudioSource audioSource;
    public static GameObject PauseMenu { get; set; }
    private bool isPaused = false;
    private GlobalKey globalKey;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    private void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = true;
    }

    private void SetPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = false;
    }
}