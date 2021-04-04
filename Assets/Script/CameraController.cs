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
        DrawCameraBoundaries();  
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

        DrawCameraBoundaries();

    }

    public void DrawCameraBoundaries()
    {
        Debug.DrawLine(new Vector2(leftBoundary, bottomBoundary), new Vector2(leftBoundary, upperBoundary), Color.green);
        Debug.DrawLine(new Vector2(leftBoundary, upperBoundary), new Vector2(rightBoundary, upperBoundary), Color.green);
        Debug.DrawLine(new Vector2(rightBoundary, upperBoundary), new Vector2(rightBoundary, bottomBoundary), Color.green);
        Debug.DrawLine(new Vector2(rightBoundary, bottomBoundary), new Vector2(leftBoundary, bottomBoundary), Color.green);
    }
}
