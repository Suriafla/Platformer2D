using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioHoverButton;
    [SerializeField] private AudioClip audioClickButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
