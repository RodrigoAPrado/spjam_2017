using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonNewGame : ButtonChangePage {

    void Start()
    {
        sceneToLoad = "NewGame";
        if (PlayerPrefs.HasKey("hasSaveFile"))
        {
            sceneToLoad = "ConfirmNewGame";
        }
    }

}
