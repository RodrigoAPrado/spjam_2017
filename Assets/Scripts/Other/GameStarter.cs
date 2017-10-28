using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour {
    void Start () {
        SceneManager.LoadScene("TitleScreen");
	}
}
