using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour, IPointerDownHandler
{
    public AudioSource audioSource;
    public AudioClip audioRespawn;

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name);
        audioSource.clip = audioRespawn;
        audioSource.Play();
    }
}
