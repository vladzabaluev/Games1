using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField]
    private Slider SFX_Slider;

    [SerializeField]
    private Slider Music_Slider;

    public void ChangeSFX_Volume()
    {
        AudioManager.SFX_Volume = SFX_Slider.value;
    }

    public void ChangeMusicVolume()
    {
        AudioManager.MusicVolume = Music_Slider.value;
        AudioManager.ChangeMainMusicVolume();
    }
}