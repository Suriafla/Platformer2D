using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private AudioClip audioPause;
    private AudioSource audioSource;
    private GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseMenu = transform.Find("Background").gameObject;
        pauseMenu.SetActive(false);
    }

    void Update()
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

    private void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = true; 
    }

    private void SetPause()
    {       
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = false;
    }
}