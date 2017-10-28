using UnityEngine;
using System.Collections;

public abstract class AudioPlayer : MonoBehaviour {

    protected VolumeController volumeController;

    protected AudioSource audioSource;

    public abstract void volumeSwitchMute();

    public abstract void volumeChangeVolume(int value);

    public abstract void updateVolume();
}
