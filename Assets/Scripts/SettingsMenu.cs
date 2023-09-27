using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField]
    private AudioMixer soundMixer = null;
    [SerializeField]
    private AudioMixer musicMixer = null;

    public void SetVolumeMusic(float volume)
    {
        musicMixer.SetFloat("Music", volume);
    }

    public void SetVolumeSound(float volume)
    {
        soundMixer.SetFloat("Sound", volume);
    }
}
