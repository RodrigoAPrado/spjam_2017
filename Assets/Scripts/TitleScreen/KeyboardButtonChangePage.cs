using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KeyboardButtonChangePage : KeyboardButton {

    [SerializeField]
    private string sceneToLoad;

    public override void doAction()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
