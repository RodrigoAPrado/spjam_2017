using UnityEngine;
using System.Collections;

public class PlayerHealthControllerPresent : PlayerHealthController {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("present_health"))
            PlayerPrefs.SetInt("present_health", 0);
        initializeHealth("present_health");
    }
}
