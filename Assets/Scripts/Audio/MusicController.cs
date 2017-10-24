using UnityEngine;
using System.Collections;

public class MusicController {

    private float musicVolume;

    private bool musicMute;

    public MusicController()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("musicVolume");
        }
        else
        {

            musicVolume = 0.8f;
        }

        if (PlayerPrefs.HasKey("musicMute"))
        {
            musicMute = PlayerPrefs.GetInt("musicMute") != 0;
        }
        else
        {
            PlayerPrefs.SetInt("musicMute", 0);
            musicMute = false;
        }
    }

    public void switchMuteMusic()
    {
        if (PlayerPrefs.GetInt("musicMute") == 0)
        {
            PlayerPrefs.SetInt("musicMute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("musicMute", 0);
        }
        musicMute = !musicMute;
    }

    public void changeMusicVolume(int changeValue)
    {
        if (changeValue != -1 && changeValue != 1)
        {
            throw new System.Exception("Volume change value must be either 1 or -1");
        }
        else
        {
            musicVolume += changeValue * 0.1f;
            PlayerPrefs.SetFloat("musicVolume", musicVolume);
            if (changeValue == 1)
            {

                if (musicVolume >= 1)
                {
                    musicVolume = 1;
                    PlayerPrefs.SetFloat("musicVolume", 1);
                }
            }
            else
            {
                if (musicVolume <= 0)
                {
                    musicVolume = 0;
                    PlayerPrefs.SetFloat("musicVolume", 0);
                }
            }
        }
    }

    public float getVolume()
    {
        return musicVolume;
    }

    public bool getMute()
    {
        return musicMute;
    }
}
