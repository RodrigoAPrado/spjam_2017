using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameRuntimeController : GameController {

    //ImplementScore

    public override void execute(string command)
    {
        SceneManager.LoadScene(command);
    }

}
