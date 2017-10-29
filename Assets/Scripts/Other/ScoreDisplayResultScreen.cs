using UnityEngine;
using System.Collections;

public class ScoreDisplayResultScreen : ScoreDisplay {

    [SerializeField]
    private TextMesh whiteTotalScore;
    [SerializeField]
    private TextMesh blackTotalScore;

    // Use this for initialization
    void Start ()
    {
        PlayerPrefs.SetInt("hasSaveFile", 1);

        setScore(whiteScore);
        setScore(blackScore);

        setTotalScore(whiteTotalScore);
        setTotalScore(blackTotalScore);
    }

    protected override void setScore(TextMesh score)
    {
        int value = PlayerPrefs.GetInt("LastScore");

        score.text = "Score: ";

        if (value < 1000)
            score.text += "0";
        if (value < 100)
            score.text += "0";
        if (value < 10)
            score.text += "0";
        score.text += value.ToString();
    }

    private void setTotalScore(TextMesh score)
    {
        int value = PlayerPrefs.GetInt("Score");

        score.text = "Total Score: ";

        if (value < 1000)
            score.text += "0";
        if (value < 100)
            score.text += "0";
        if (value < 10)
            score.text += "0";
        if (value > 9999)
            score.text += "9999+";
        else
            score.text += value.ToString() + " ";
    }
}
