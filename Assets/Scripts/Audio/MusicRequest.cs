using UnityEngine;
using System.Collections;

public class MusicRequest : MonoBehaviour {

    private MusicFile music;

    [SerializeField]
    string musicName;

    [SerializeField]
    float loopStart = 0;

    [SerializeField]
    float loopEnd = 0;

    [SerializeField]
    float baseVolume = 1;

    // Use this for initialization
    void Start () {

       

        music = new MusicFile("Audio/Musics/" + musicName, baseVolume, loopStart, loopEnd);

        GameObject.FindGameObjectWithTag("MusicSource").GetComponent<MusicPlayer>().setMusic(music);

        GameObject.Destroy(this.gameObject);
	}
}
