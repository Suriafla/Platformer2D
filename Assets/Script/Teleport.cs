using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public AudioClip audioTeleport;
    public Transform pointTeleport;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void teleport(Collider2D collision)
    {
        audioSource.PlayOneShot(audioTeleport);
        collision.gameObject.transform.position = pointTeleport.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Name = " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {

            teleport(collision);
        }
    }

}
