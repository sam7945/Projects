using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Formation formation;
    public float padding = 2f; // Padding around the formation
    public Camera mainCamera;

    void Start()
    {
        
        GameObject cameraObject = GameObject.FindWithTag("MainCamera");
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();
            if (mainCamera != null)
            {
                formation = gameObject.GetComponent(typeof(Formation)) as Formation;
                AdjustCamera();
            }
            else
            {
                Debug.LogError("No Camera component found on " + cameraObject.name);
            }
        }
        else
        {
            Debug.LogError("Camera object not found");
        }
    }

    void AdjustCamera()
    {
        // Calculate the aspect ratio of the camera
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = formation.GetSize() / GameSettings._nbRow;

        // If the screen ratio is less than the target ratio, adjust the orthographic size
        if (screenRatio < targetRatio)
        {
            float differenceInSize = targetRatio / screenRatio;
            AjustSize((GameSettings._nbRow / 2 * differenceInSize + padding) * 1.5f);
        }
        // Else the screen ratio is greater than or equal to the target ratio, so adjust the orthographic size based on the formation size
        else
        {
            AjustSize((formation.GetSize() / 2 + padding) * 1.5f);
        }
        
        
    }


    void AjustSize(float size)
    {
        // Ensure the size is never less than 65
        if(size < 65)
        {
            size = 65;
        }
        
        mainCamera.orthographicSize = size;
        //4.16 is a magic number to ajust the camera so the space ship is in view
        mainCamera.transform.position = new Vector3(0, (size- 4.16f), -22.57f);
        
    }
}