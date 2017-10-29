using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {

    public int debugScore;

    void Start () {

        //PlayerPrefs.SetInt("Score", debugScore);

        //PlayerPrefs.SetInt("hasSaveFile", 1);
        SceneManager.LoadScene("TitleScreen");
	}
}
