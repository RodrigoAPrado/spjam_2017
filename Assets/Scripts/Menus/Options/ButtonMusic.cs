using UnityEngine;
using System.Collections;

public class ButtonMusic : ButtonAudio {

	// Use this for initialization
	void Start () {
        audioPlayer = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<MusicPlayer>();
    }
}
