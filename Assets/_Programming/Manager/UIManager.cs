using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    #region Arguments

    private UIState m_currentState;
    [SerializeField] private GameObject m_optionCanvas;

    #endregion

    #region Initialization

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

        ChangeState(UIState.Nothing);
    }

    #endregion

    // State Machine
    public void ChangeState(UIState newState)
    {
        m_currentState = newState;

        switch (newState)
        {
            case UIState.Nothing :
                m_optionCanvas.SetActive(false);
                break;
            case UIState.Option :
                m_optionCanvas.SetActive(true);
                break;
            default :
                break;
        }
    }

    public UIState GetCurrentState()
    {
        return m_currentState;
    }
}

public enum UIState
{
    Nothing,
    Option
}