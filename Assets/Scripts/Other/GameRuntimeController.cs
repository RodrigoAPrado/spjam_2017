using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class GameRuntimeController : GameController {

    ScoreController scoreController;

    void Start()
    {
        scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
    }

    public override void execute(string command)
    {
        saveScore();
        SceneManager.LoadScene(command);
    }

    private void saveScore()
    {
        PlayerPrefs.SetInt("LastScore", scoreController.getScore());
        if (PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + scoreController.getScore());
        }
        else
        {
            PlayerPrefs.SetInt("Score", scoreController.getScore());
        }
    }

}
