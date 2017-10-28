using UnityEngine;
using System.Collections;

public class ScoreController : GameController {

    [SerializeField]
    private TextMesh blackText;
    [SerializeField]
    private TextMesh whiteText;

    private int score;
    private string scoreText;

    // Use this for initialization
    void Start () {
        score = 0;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            execute("ok");
        }
    }

    public override void execute(string test)
    {
        score = score + 1;

        scoreText = setScoreText();
        blackText.text = scoreText;
        whiteText.text = scoreText;
    }

    public string setScoreText()
    {
        string baseText = "Score :";
        string text = baseText;

        if (score < 1000)
        {
            text += "0";
        }

        if (score < 100)
        {
            text += "0";
        }

        if (score < 10)
        {
            text += "0";
        }

        text += score.ToString();

        return text;
    }

    public int getScore()
    {
        return score;
    }
}
