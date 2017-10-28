using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TutorialController : GameController {

	// Use this for initialization
	void Start () {
        execute("Game");
	}

    public override void execute(string command)
    {
        SceneManager.LoadScene(command);
    }
}
