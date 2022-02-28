using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpIntegration : MonoBehaviour
{
    #region Events

    public delegate void OnSendPosition(Vector3 currentPosition, float completionRate); // the forth value is the completion rate
    public event OnSendPosition onSendPosition;

    #endregion

    #region Arguments

    private Vector3 m_originalPosition;
    private Vector3 m_targetPosition;
    private Vector3 m_currentPosition;
    
    private float m_duration;
    private float m_startingTime;

    private bool m_isLerping;

    #endregion
    
    #region Methods

    public void Launch(Vector3 originalPosition, Vector3 targetPosition, float duration)
    {
        m_originalPosition = originalPosition;
        m_targetPosition = targetPosition;

        m_duration = duration;
        m_startingTime = Time.time;

        m_isLerping = true;
    }

    void Update()
    {
        if (m_isLerping)
            CalculatePosition();
    }

    void CalculatePosition()
    {
        float m_timeSinceStarted = Time.time - m_startingTime;
        float m_completionRate = m_timeSinceStarted / m_duration;

        m_currentPosition = Vector3.Lerp(m_originalPosition, m_targetPosition, m_completionRate);

        if (m_completionRate >= 1)
        {
            m_isLerping = false;
        }

        onSendPosition?.Invoke(m_currentPosition, m_completionRate);
    }
    
    #endregion
}
