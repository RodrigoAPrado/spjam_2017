using UnityEngine;
using System.Collections;

public class PlayerHealthControllerFuture : PlayerHealthController {

    // Use this for initialization
    void Start()
    {
        if (!PlayerPrefs.HasKey("future_health"))
            PlayerPrefs.SetInt("future_health", 0);
        initializeHealth("future_health");
    }
}
