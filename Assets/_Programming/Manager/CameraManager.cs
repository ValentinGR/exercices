using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Singleton

    private static CameraManager m_instance;
    public static CameraManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                GameObject container = new GameObject("Camera Manager");
                container.AddComponent<CameraManager>();
            }

            return m_instance;
        }
    }

    #endregion

    #region Events

    public delegate void OnChangeState(CameraState newState);
    public static event OnChangeState onChangeState;

    #endregion

    private CameraState m_currentState;

    void Awake()
    {
        if (m_instance == null)
            m_instance = this;
            
        ChangeState(CameraState.Idle);
    }


    // State Machine
    public void ChangeState(CameraState newState)
    {
        m_currentState = newState;

        switch (newState)
        {
            case CameraState.Idle :
                break;
            case CameraState.Walking :
                break;
            case CameraState.Bumping :
                break;
            case CameraState.Rotate :
                break;
            default :
                break;
        }

        onChangeState?.Invoke(newState);
    }

    public CameraState GetCurrentState()
    {
        return m_currentState;
    }
}

public enum CameraState
{
    Idle,
    Walking,
    Bumping,
    Rotate
}