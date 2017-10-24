using UnityEngine;
using System.Collections;

public class AudioFile {

    protected AudioClip audio;
    protected float baseVolume;
    protected float baseSpeed;

    public AudioFile()
    {

    }

    public AudioFile(string audioPath, float baseVolume = 1, float baseSpeed = 1)
    {
        this.audio = Resources.Load(audioPath) as AudioClip;
        this.baseVolume = baseVolume;
        this.baseSpeed = baseSpeed;
    }

    public float getVolume()
    {
        return baseVolume;
    }

    public float getSpeed()
    {
        return baseSpeed;
    }

    public AudioClip getAudio()
    {
        return audio;
    }
}
