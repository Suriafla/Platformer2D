﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip audioPause;
    public GameObject pauseMenu;
    public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.PlayOneShot(audioPause);
            if (gamePaused)
            {
                Resume();
            }
            else makePause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = true; 
    }

    public void makePause()
    {       
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        GameObject temp = GameObject.Find("Hero");
        temp.GetComponent<HeroController>().enabled = false;

    }
}
