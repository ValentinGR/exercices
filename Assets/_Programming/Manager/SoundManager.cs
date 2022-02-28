using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject g = new GameObject("Sound Manager");
                g.AddComponent<SoundManager>();
            }

            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        DefineLists();
    }
    
    #endregion

    public VolumeManager CurrentVolume {get ; private set ;}

    private SoundList[] allLists;

    void DefineLists()
    {
        allLists = new SoundList[3];

        CurrentVolume = Resources.Load<VolumeManager>("ScriptableObjects/Audio/VolumeManager");

        allLists[0] = Resources.Load<SoundList>("ScriptableObjects/Audio/SoundList/Musics");
        allLists[1] = Resources.Load<SoundList>("ScriptableObjects/Audio/SoundList/EnvironmentSounds");
        allLists[2] = Resources.Load<SoundList>("ScriptableObjects/Audio/SoundList/UISounds");
    }

    public void PlaySound(int currentRegion, int ID, AudioSource usableSource)
    {
        #region Security Check

        if (currentRegion >= allLists.Length)
        {
            Debug.LogError("L'index envoyé est plus élevé que le nombre de List de Region");
            return;
        }
        else if (ID >= allLists[currentRegion].GetLenght())
        {
            Debug.LogError("L'index envoyé est plus élevé que le nombre de son dans la liste");
            return;
        }
        if (currentRegion >= CurrentVolume.GetVolumeTypesLength())
        {
            Debug.LogError("L'index envoyé est plus élevé que le nombre de paramètre de gestion de Volume");
            return;
        }

        #endregion
    
        if (allLists[currentRegion].GetASound(ID).GetAudioClip() != null)
            usableSource.PlayOneShot(allLists[currentRegion].GetASound(ID).GetAudioClip(), CurrentVolume.GetVolume(currentRegion));
    }
}
