using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Events

    public delegate void OnMovement(Vector2 movementValue);
    public static event OnMovement onMovement;

    public delegate void OnRotation(Vector2 rotationValue);
    public static event OnRotation onRotation;

    #endregion

    private Vector2 m_inputValue;
    private bool m_inputsIsPressed;

    // Send action event based on Movement Inputs Data
    void Update()
    {
        if (m_inputsIsPressed)
        {
            if (m_inputValue.x != 0)
                onRotation?.Invoke(m_inputValue);
            else if (m_inputValue.y != 0)
                onMovement?.Invoke(m_inputValue);
        } 
    }

    // Receive Movement Inputs Data
    public void MovementInputs(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.GetCurrentState() == GameState.Paused)
            return;
            
        m_inputValue = context.ReadValue<Vector2>();

        m_inputValue.x = m_inputValue.x.SignedValueTo1();
        m_inputValue.y = m_inputValue.y.SignedValueTo1();

        if (context.performed)
            m_inputsIsPressed = true;

        if (context.canceled)
            m_inputsIsPressed = false;  
    }

    // Receive Pause Inputs Data
    public void PauseInputs(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameManager.Instance.CheckPause();
        }
    }
}