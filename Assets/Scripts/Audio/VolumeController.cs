using UnityEngine;
using System.Collections;

public class VolumeController {

    protected string type;

    public VolumeController(string type)
    {

        if(type != "music" && type != "sfx")
        {
            throw new System.Exception("Type of volume controller must be either music or sfx.");
        }

        if (!PlayerPrefs.HasKey(type + "Volume"))
        {
            PlayerPrefs.SetFloat(type + "Volume", 0.8f);
        }

        if (!PlayerPrefs.HasKey(type + "Mute"))
        {
            PlayerPrefs.SetInt(type + "Mute", 0);
        }

        this.type = type;
    }

    public void switchMute()
    {
        if (PlayerPrefs.GetInt(type + "Mute") == 0)
        {
            PlayerPrefs.SetInt(type + "Mute", 1);
        }
        else
        {
            PlayerPrefs.SetInt(type + "Mute", 0);
        }
    }

    public void changeVolume(int changeValue)
    {
        if (changeValue != -1 && changeValue != 1)
        {
            throw new System.Exception("Volume change value must be either 1 or -1");
        }

        float volume = PlayerPrefs.GetFloat(type + "Volume");
        volume += changeValue * 0.1f;
        PlayerPrefs.SetFloat(type + "Volume", volume);
        if (changeValue == 1)
        {
            if (volume >= 1)
            {
                PlayerPrefs.SetFloat(type + "Volume", 1);
            }
        }
        else
        {
            if (volume <= 0)
            {
                PlayerPrefs.SetFloat(type + "Volume", 0);
            }
        }
    }
}
