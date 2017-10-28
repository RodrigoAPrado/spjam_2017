using UnityEngine;
using System.Collections;

public class GameReseter : GameController {
    
    public override void execute(string command)
    {
        int muteSfx = PlayerPrefs.GetInt("sfxMute");
        float volumeSfx = PlayerPrefs.GetFloat("sfcVolume");

        int muteMusic = PlayerPrefs.GetInt("musicMute");
        float volumeMusic = PlayerPrefs.GetFloat("musicVolume");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("sfxVolume", volumeSfx);
        PlayerPrefs.SetInt("sfxMute", muteSfx);

        PlayerPrefs.SetFloat("musicVolume", volumeMusic);
        PlayerPrefs.SetInt("musicMute", muteMusic);
    }
}
