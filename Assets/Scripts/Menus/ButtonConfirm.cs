using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonConfirm : ButtonChangePage {
    protected GameController gameController;

    protected string command;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").
                                        GetComponent<GameController>();

        sceneToLoad = "NewGame";
        command = "";
    }

    public override void doAction()
    {
        gameController.execute(command);
        SceneManager.LoadScene(sceneToLoad);
    }

}
