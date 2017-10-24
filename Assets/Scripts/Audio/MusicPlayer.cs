using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
    
    private MusicFile defaultMusic;
    
    private MusicFile currentMusic;

    private MusicController musicController;

    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        Object.DontDestroyOnLoad(this.gameObject);

        musicController = new MusicController();

        defaultMusic = new MusicFile("MINHAROLA/Hip");

        currentMusic = defaultMusic;

        audioSource = gameObject.GetComponent<AudioSource>();

        if(audioSource == null)
        {
            throw new System.Exception("Game object does not have an Audio Source. Cannot play music");
        }
        startMusic();
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

    void startMusic()
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

    void musicSettings()
    {
        audioSource.volume = musicController.getVolume() * currentMusic.getVolume();
        audioSource.mute = musicController.getMute();
    }
    
}
