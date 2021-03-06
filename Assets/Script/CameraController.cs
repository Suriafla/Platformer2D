using UnityEngine;

/// <summary>
/// Сlass controls the main camera
/// </summary>
public class CameraController : MonoBehaviour
{
    private Vector2 heroPosition;
    private Vector2 cameraPosition;
    private Transform cameraTransform;
    private GameObject hero;
    private readonly float leftBoundary = 47;
    private readonly float upperBoundary = 33;
    private readonly float bottomBoundary = 20;
    private readonly float rightBoundary = 230;

    void Start()
    {
        hero = GameObject.Find("Hero");
        cameraTransform = GetComponent<Transform>();
        cameraPosition.x = cameraTransform.position.x;
        cameraPosition.y = cameraTransform.position.y;     
    }

    void Update()
    {
        FollowToHero();
    }

    /// <summary>
    /// Method draws the boundaries of the camera center movement in the editor,
    /// used for debugging
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(leftBoundary, bottomBoundary, 0), new Vector3(leftBoundary, upperBoundary, 0));
        Gizmos.DrawLine(new Vector3(leftBoundary, upperBoundary, 0), new Vector3(rightBoundary, upperBoundary, 0));
        Gizmos.DrawLine(new Vector3(rightBoundary, upperBoundary, 0), new Vector3(rightBoundary, bottomBoundary, 0));
        Gizmos.DrawLine(new Vector3(rightBoundary, bottomBoundary, 0), new Vector3(leftBoundary, bottomBoundary, 0));
    }

    /// <summary>
    /// Method indicates the camera to follow the main character
    /// </summary>
    private void FollowToHero()
    {
        heroPosition = hero.transform.position;
        heroPosition.x = hero.transform.position.x;
        heroPosition.y = hero.transform.position.y;
        //Lerp smooths change
        cameraPosition = Vector2.Lerp(cameraPosition, heroPosition, Time.deltaTime);

        // Mathf.Clamp specifies in what bounds (second and third arguments)
        // the value for the first argument should be. if the value is greater,
        // then the argument takes an upper bound. Similarly if the value is less
        cameraTransform.position = new Vector3
            (
               Mathf.Clamp(cameraPosition.x, leftBoundary, rightBoundary),
               Mathf.Clamp(cameraPosition.y, bottomBoundary, upperBoundary),
              cameraTransform.position.z
            );
    }
}
