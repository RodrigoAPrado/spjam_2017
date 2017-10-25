using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KeyboardButtonPlay : KeyboardButton {
    
    private string sceneToLoad = "Game";

    public override void doAction()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
