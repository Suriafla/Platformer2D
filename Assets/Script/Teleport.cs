using UnityEngine;

/// <summary>
/// Class to works with teleports
/// </summary>
public class Teleport : MonoBehaviour
{
    [SerializeField] private AudioClip audioTeleport;
    private AudioSource audioSource;

    public Vector3 PointTeleport { get; private set; } = new Vector3(158, 29, 0);

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Method moves objects, that went into trigger, to pointTeleport
    /// </summary>
    /// <param name="collision">collider objects that enter into trigger</param>
    private void TeleportToPoint(Collider2D collision)
    {
        audioSource.PlayOneShot(audioTeleport);
        collision.gameObject.transform.position = PointTeleport;
    }

    /// <summary>
    /// Teleport objects with tag "Player"
    /// </summary>
    /// <param name="collision">collider objects that enter into trigger</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportToPoint(collision);
        }
    }
}
