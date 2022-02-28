using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    #region Initialisation && Events Subscription

    void Awake()
    {
        m_lerpIntegration = gameObject.AddComponent<LerpIntegration>();
        m_lerpIntegration.onSendPosition += DefineRotation;
    }

    void OnEnable()
    {
        PlayerController.onRotation += RotateCamera;
    }

    void OnDisable()
    {
        m_lerpIntegration.onSendPosition -= DefineRotation;
        PlayerController.onRotation -= RotateCamera;
    }

    #endregion

    LerpIntegration m_lerpIntegration;
    
    // Launch Rotation Movement
    void RotateCamera(Vector2 inputValue)
    {
        if (CameraManager.Instance.GetCurrentState() == CameraState.Idle)
        {
            m_lerpIntegration.Launch(transform.rotation.eulerAngles, transform.rotation.eulerAngles + new Vector3(0, inputValue.x * 90, 0), 0.2f);
            CameraManager.Instance.ChangeState(CameraState.Rotate);
        }
    }

    // Define the rotation based on the lerp returned value 
    void DefineRotation(Vector3 currentRotation, float completionRate)
    {
        transform.rotation = Quaternion.Euler(currentRotation);
        if (completionRate >= 1)
            CameraManager.Instance.ChangeState(CameraState.Idle);
    }
}
