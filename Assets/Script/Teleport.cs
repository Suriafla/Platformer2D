using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private AudioClip audioTeleport;
    private Vector3 pointTeleport;
    private AudioSource audioSource;

    private void Start()
    {
        pointTeleport = new Vector3(158, 29, 0);
        audioSource = GetComponent<AudioSource>();
    }

    private void TeleportToPoint(Collider2D collision)
    {
        audioSource.PlayOneShot(audioTeleport);
        collision.gameObject.transform.position = pointTeleport;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Name = " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportToPoint(collision);
        }
    }
}
