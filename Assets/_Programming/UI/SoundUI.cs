using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [SerializeField] private int m_soundType;
    private Slider m_slider;

    void Start()
    {
        m_slider = GetComponent<Slider>();
        m_slider.value = SoundManager.Instance.CurrentVolume.GetVolume(m_soundType);
    }

    public void DefineVolumeUI()
    {
        float volume = m_slider.value;
        SoundManager.Instance.CurrentVolume.ChangeTheVolume(m_soundType, (int)volume);
    }
}
