using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MyAssets/Audio/SoundList")]
public class SoundList : ScriptableObject
{
    [SerializeField] private Sound[] SoundsByType;

    public int GetLenght()
    {
        return SoundsByType.Length;
    }

    public Sound GetASound(int index)
    {
        return SoundsByType[index];
    }
}