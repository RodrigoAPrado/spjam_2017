using UnityEngine;
using System.Collections;

public class MusicPlayer : AudioPlayer {
    
    private MusicFile defaultMusic;
    
    private MusicFile currentMusic;

    // Use this for initialization
    void Start () {
        Object.DontDestroyOnLoad(this.gameObject);

        volumeController = new VolumeController("music");

        defaultMusic = new MusicFile("Audio/Musics/Hip");

        audioSource = gameObject.GetComponent<AudioSource>();

        if(audioSource == null)
        {
            throw new System.Exception("Game object does not have an Audio Source. Cannot play music");
        }

        setMusic(defaultMusic);
    }
	
	// Update is called once per frame
	void Update () {
        if(currentMusic.getLoopEnd() != 0)
        {
            if(audioSource.time >= currentMusic.getLoopEnd())
            {
                audioSource.time = currentMusic.getLoopStart();
            }
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
        musicSettings();
    }

    public void setMusic(MusicFile musicToPlay)
    {
        if (currentMusic == null || musicToPlay.getAudio() != currentMusic.getAudio())
        {
            currentMusic = musicToPlay;
            startMusic();
        }
    }

    private void startMusic()
    {
        if(currentMusic == null)
        {
            throw new System.Exception("Current music is invalid or non-existent. Cannot play music");
        }
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = currentMusic.getAudio();
        musicSettings();
        audioSource.Play();
        
    }

    private void musicSettings()
    {
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume") * currentMusic.getVolume();
        audioSource.mute = PlayerPrefs.GetInt("musicMute") == 0? false : true;
    }

    public void resetToDefault()
    {
        setMusic(defaultMusic);
    }
    
}
