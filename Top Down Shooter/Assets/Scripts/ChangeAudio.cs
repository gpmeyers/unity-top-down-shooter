using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    public Slider slider;

    public void ChangeVolume()
    {
        GetComponent<AudioSource>().volume = slider.value;
    }
}
