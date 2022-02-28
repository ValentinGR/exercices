using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    #region Events

    public static event Action onPlaying;
    public static event Action onPausing;

    #endregion

    public static GameManager Instance;

    private GameState m_currentState;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        
        ChangeState(GameState.Playing);
    }

    // State Machine
    public void ChangeState(GameState newState)
    {
        m_currentState = newState;

        switch (newState)
        {
            case GameState.Playing :
                UIManager.Instance.ChangeState(UIState.Nothing);
                Time.timeScale = 1;
                break;
            case GameState.Paused :
                UIManager.Instance.ChangeState(UIState.Option);
                Time.timeScale = 0;
                break;
            default :
                break;
        }
    }

    public void CheckPause()
    {
        if (m_currentState == GameState.Playing)
            ChangeState(GameState.Paused);
        else
            ChangeState(GameState.Playing);
    }

    public GameState GetCurrentState()
    {
        return m_currentState;
    }
}


public enum GameState
{
    Playing,
    Paused
}