using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyAssets/Audio/Volume")]
public class VolumeManager : ScriptableObject
{
    [Header("0 == Music // 1 == Enviro // 2 == UI")]
    [Range(0,100)]
    [SerializeField] private int[] VolumeGestion;

    #region Events
    
    public delegate void OnChangeVolume(float volume);

    public void ChangeTheVolume(int soundType, int volume)
    {
        VolumeGestion[soundType] = volume;
    }

    #endregion

    #region Methods

    public float GetVolume(int soundType)
    {
        if (soundType < 0)
            return 0;
        if (soundType > VolumeGestion.Length)
            return 0;
        
        return (VolumeGestion[soundType]);
    }

    public int GetVolumeTypesLength()
    {
        return VolumeGestion.Length;
    }

    #endregion
}
