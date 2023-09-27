using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;

    [SerializeField]
    AudioSource playOneShot = null;
    [SerializeField]
    AudioSource flashAudioSource = null;
    [SerializeField]
    AudioClip buttonSound = null;
    [SerializeField]
    AudioClip jumpSound = null;
    [SerializeField]
    AudioClip flashSound = null;

    void Awake()
    {
        soundManager = this;
    }

    public void PlayJump()
    {
        playOneShot.PlayOneShot(jumpSound);
    }

    public void PlayFlash()
    {
        flashAudioSource.PlayOneShot(flashSound);
    }

    public void PlayButton()
    {
        playOneShot.PlayOneShot(buttonSound);
    }

}
