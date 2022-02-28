using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyAssets/Audio/Sound")]
public class Sound : ScriptableObject
{
    #region Arguments

    [SerializeField] private AudioClip m_mySound;
    [SerializeField] private int m_id;
    [SerializeField] private int m_soundType; // 0 == music // 1 == environnement // 2 == UI

    #endregion

    #region Get Methods

    public AudioClip GetAudioClip()
    {
        return m_mySound;
    }

    public int GetID()
    {
        return m_id;
    }

    public int GetSoundType()
    {
        return m_soundType;
    }

    #endregion
}