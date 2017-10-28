using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonContinue : ButtonChangePage {

    void Start()
    {
        sceneToLoad = "Game";
        if (!PlayerPrefs.HasKey("hasSaveFile"))
        {
            disabled = true;
        }
    }
}
