using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    Camera currentCamera;
    
	void Start () 
	{
        if (GetComponent<Camera>())
            currentCamera = GetComponent<Camera>();
        else
            Destroy(this);
		CheckCameraSize();
	}

	public void CheckCameraSize()
	{
        float targetAspect = 16f / 9f;
        float currentAspect = (float)Screen.width / (float)Screen.height;

        float heightRatioDifference = currentAspect / targetAspect;
        

        Rect rect = currentCamera.rect;
        if (heightRatioDifference == 1f)
        {
            rect.width = 1;
            rect.height = 1;
            rect.x = 0;
            rect.y = 0;

        }
        else if (heightRatioDifference < 1f)
        {
            rect.width = 1;
            rect.height = heightRatioDifference;
            rect.x = 0;
            rect.y = (1f - heightRatioDifference) / 2f;
            
        }
        else if (heightRatioDifference > 1)
        {
            float widthRatioDifference = 1f / heightRatioDifference;

            rect.width = widthRatioDifference;
            rect.height = 1;
            rect.x = (1f - widthRatioDifference) / 2f;
            rect.y = 0;
        }

        currentCamera.rect = rect;
    }
}