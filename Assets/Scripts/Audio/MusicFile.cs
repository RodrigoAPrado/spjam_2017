using UnityEngine;
using System.Collections;

public class MusicFile : AudioFile {

    private float loopStart;
    private float loopEnd;

    public MusicFile(string musicPath, 
                    float baseVolume = 1, 
                    float loopStart = 0, 
                    float loopEnd = 0, 
                    float baseSpeed = 1)
    {
        this.audio = Resources.Load(musicPath) as AudioClip;
        this.baseVolume = baseVolume;
        this.loopStart = loopStart;
        this.loopEnd = loopEnd;
        this.baseSpeed = baseSpeed;
    }

    public float getLoopStart()
    {
        return loopStart;
    }

    public float getLoopEnd()
    {
        return loopEnd;
    }
}
