using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolutions : MonoBehaviour
{
    [SerializeField] private int[] m_weights;
    [SerializeField] private int[] m_heights;

    public void DefineResolution(Dropdown state)
    {
        if (state.value < 0)
            return;
        if (state.value > m_weights.Length && state.value > m_heights.Length)
            return;

        Screen.SetResolution(m_weights[state.value], m_heights[state.value], true);
    }
}
