using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {


    [SerializeField]
    protected TextMesh whiteScore;
    [SerializeField]
    protected TextMesh blackScore;

    // Use this for initialization
    void Start () {

        setScore(whiteScore);
        setScore(blackScore);
    }

    protected virtual void setScore(TextMesh score)
    {
        int value = PlayerPrefs.GetInt("Score");

        score.text = "Score: ";

        if (value < 1000)
            score.text += "0";
        if (value < 100)
            score.text += "0";
        if (value < 10)
            score.text += "0";
        score.text += value.ToString();
    }
}
