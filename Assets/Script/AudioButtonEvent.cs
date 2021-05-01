using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Class for 
/// </summary>
public class AudioButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioHoverButton;
    [SerializeField] private AudioClip audioClickButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Method is triggered when the button down
    /// </summary>
    public void OnPointerDown(PointerEventData eventData)
    {
        audioSource.PlayOneShot(audioClickButton);
    }

    /// <summary>
    /// Method is triggered when you hover over the button
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(audioHoverButton);
    }
}
