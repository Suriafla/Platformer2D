using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public AudioSource audioSource;
    public AudioClip audioHoverButton;
    public AudioClip audioClickButton;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name);
        audioSource.PlayOneShot(audioClickButton);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(audioHoverButton);
    }
}
