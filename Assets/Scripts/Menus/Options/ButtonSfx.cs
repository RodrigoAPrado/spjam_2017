using UnityEngine;
using System.Collections;

public class ButtonSfx : ButtonAudio {

	// Use this for initialization
	void Start () {
        audioPlayer = GameObject.FindGameObjectWithTag("SfxSource").GetComponent<SfxPlayer>();
	}
}
