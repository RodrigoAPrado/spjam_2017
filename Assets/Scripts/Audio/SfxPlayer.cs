using UnityEngine;
using System.Collections;
using System;

public class SfxPlayer : AudioPlayer {

    private AudioFile defaultSfx;

    void Start()
    {
        defaultSfx = new AudioFile("");
    }

    public override void updateVolume()
    {
        audioSource.PlayOneShot(defaultSfx);
    }

    public override void volumeChangeVolume(int value)
    {
        throw new NotImplementedException();
    }

    public override void volumeSwitchMute()
    {
        throw new NotImplementedException();
    }

}
