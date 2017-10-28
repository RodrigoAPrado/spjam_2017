using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonChangePage : Button {

    protected string sceneToLoad;

    public override void doAction()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
