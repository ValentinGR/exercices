using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{

    #region Events Subscription

    void OnEnable()
    {
        PlayerController.onMovement += Walk;
    }

    void OnDisable()
    {
        m_lerpIntegration.onSendPosition -= DefinePosition;
        PlayerController.onMovement -= Walk;
    }

    #endregion

    #region Arguments

        #region Class References
        LerpIntegration m_lerpIntegration;
        RaycastTest m_raycastTest;
        #endregion

    private float m_originalYPosition;
    private float m_currentDirection;

    #endregion

    #region Initialization

    void Awake()
    {
        m_lerpIntegration = gameObject.AddComponent<LerpIntegration>();
        m_lerpIntegration.onSendPosition += DefinePosition;

        m_raycastTest = gameObject.AddComponent<RaycastTest>();

        m_originalYPosition = transform.position.y;
    }

    #endregion

    // Launch Walk Movement
    void Walk(Vector2 inputValue)
    {
        if (CameraManager.Instance.GetCurrentState() == CameraState.Idle)
        {
            // Check if there is an obstacle
            if (m_raycastTest.RaycastCheckTag(transform.position, transform.forward * inputValue.y) == "Wall")
            {
                m_lerpIntegration.Launch(transform.position, transform.position + (transform.forward * inputValue.y) / 4.5f, 0.15f);
                m_currentDirection = inputValue.y;
                CameraManager.Instance.ChangeState(CameraState.Bumping);
            }
            else
            {
                m_lerpIntegration.Launch(transform.position, transform.position + transform.forward * inputValue.y, 0.35f);
                m_currentDirection = inputValue.y;
                CameraManager.Instance.ChangeState(CameraState.Walking);
            }
        }
    }

    // Define the position based on the lerp returned value 
    void DefinePosition(Vector3 currentPosition, float completionRate)
    {
        currentPosition.y = m_originalYPosition;
        transform.position = currentPosition;
        if (completionRate >= 1)
            EndMovement();
    }

    void EndMovement()
    {
        // If is Bumping -> Move backward
        if (CameraManager.Instance.GetCurrentState() == CameraState.Bumping)
        {
            m_lerpIntegration.Launch(transform.position, transform.position + (-transform.forward * m_currentDirection) / 4.5f, 0.15f);
            CameraManager.Instance.ChangeState(CameraState.Walking);
        }
        else
        {
            CameraManager.Instance.ChangeState(CameraState.Idle);
        }
    }
}
