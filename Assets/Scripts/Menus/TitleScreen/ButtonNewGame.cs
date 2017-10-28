using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonNewGame : ButtonChangePage {

    void Start()
    {
        sceneToLoad = "Game";
        if (PlayerPrefs.HasKey("hasSaveFile"))
        {
            sceneToLoad = "ConfirmNewGame";
        }
    }

}
