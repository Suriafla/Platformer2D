using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 heroPosition;
    private Vector2 cameraPosition;
    private Transform cameraTransform;
    public GameObject hero;

    public float leftBoundary;
    public float rightBoundary;
    public float bottomBoundary;
    public float upperBoundary;


    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = GetComponent<Transform>();
        cameraPosition.x = cameraTransform.position.x;
        cameraPosition.y = cameraTransform.position.y;     
    }

    // Update is called once per frame
    void Update()
    {
        heroPosition = hero.transform.position;
        heroPosition.x = hero.transform.position.x;
        heroPosition.y = hero.transform.position.y;
        cameraPosition = Vector2.Lerp(cameraPosition, heroPosition, Time.deltaTime);

        cameraTransform.position = new Vector3
            (
               Mathf.Clamp(cameraPosition.x, leftBoundary, rightBoundary),
               Mathf.Clamp(cameraPosition.y, bottomBoundary, upperBoundary),
              cameraTransform.position.z
            );

   

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(leftBoundary, bottomBoundary, 0), new Vector3(leftBoundary, upperBoundary, 0));
        Gizmos.DrawLine(new Vector3(leftBoundary, upperBoundary, 0), new Vector3(rightBoundary, upperBoundary, 0));
        Gizmos.DrawLine(new Vector3(rightBoundary, upperBoundary, 0), new Vector3(rightBoundary, bottomBoundary, 0));
        Gizmos.DrawLine(new Vector3(rightBoundary, bottomBoundary, 0), new Vector3(leftBoundary, bottomBoundary, 0));
    }
}
