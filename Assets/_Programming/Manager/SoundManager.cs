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
                GameObject g = GameObject.Find("Sounds");
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
        DefineAudioSource();
    }
    
    #endregion

    public VolumeManager CurrentVolume {get ; private set ;}

    private SoundList[] allLists;
    public AudioSource[] allSources { get ; private set ; }

    void DefineLists()
    {
        allLists = new SoundList[3];

        CurrentVolume = Resources.Load<VolumeManager>("ScriptableObjects/Audio/VolumeManager");

        allLists[0] = Resources.Load<SoundList>("ScriptableObjects/Audio/SoundList/Musics");
        allLists[1] = Resources.Load<SoundList>("ScriptableObjects/Audio/SoundList/EnvironmentSounds");
        allLists[2] = Resources.Load<SoundList>("ScriptableObjects/Audio/SoundList/UISounds");
    }

    void DefineAudioSource()
    {
        allSources = new AudioSource[3];

        int count = 0;

        while (count < allSources.Length)
        {
            allSources[count] = transform.GetChild(count).GetComponent<AudioSource>();
            allSources[count].volume = CurrentVolume.GetVolume(count);

            count++;
        }
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

    public void PlaySound(int currentRegion, int ID)
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
            allSources[currentRegion].PlayOneShot(allLists[currentRegion].GetASound(ID).GetAudioClip(), CurrentVolume.GetVolume(currentRegion) / 100f);
    }
}
