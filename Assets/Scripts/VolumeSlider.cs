using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public static VolumeSlider instance;
    [SerializeField] Slider volumeSlider;
    public float volume;

    private void Start()
    {
        instance = this;
    }

    public void ChangeVolume()
    {
        volume = volumeSlider.value;
        AudioListener.volume = volume;
    }
}
