using UnityEngine;
using System.Collections;
using System;

public class SfxPlayer : AudioPlayer {

    private AudioFile defaultSfx;

    void Start()
    {
        volumeController = new VolumeController("sfx");

        defaultSfx = new AudioFile("Audio/test");

        audioSource = gameObject.GetComponent<AudioSource>();

        if (audioSource == null)
        {
            throw new System.Exception("Game object does not have an Audio Source. Cannot play sound effect");
        }
    }
    
    public override void volumeChangeVolume(int value)
    {
        volumeController.changeVolume(value);
        updateVolume();
    }

    public override void volumeSwitchMute()
    {
        volumeController.switchMute();
        updateVolume();
    }

    public override void updateVolume()
    {
        playSoundEffect(defaultSfx);
    }

    public void playSoundEffect(AudioFile audio)
    {
        audioSource.volume = defaultSfx.getVolume() * PlayerPrefs.GetFloat("sfxVolume");
        audioSource.mute = PlayerPrefs.GetInt("sfxMute") == 0 ? false : true;
        audioSource.PlayOneShot(defaultSfx.getAudio());
    }

}
