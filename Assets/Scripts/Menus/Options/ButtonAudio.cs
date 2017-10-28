using UnityEngine;
using System.Collections;

public class ButtonAudio : Button {

    protected AudioPlayer audioPlayer;

	void Update () {
        if (selected && !disabled)
        {
            if (Input.GetButtonDown("Submit"))
            {
                doAction();
            }
            else if (Input.GetButtonDown("Left"))
            {
                doSecondAction(-1);
            }
            else if (Input.GetButtonDown("Right"))
            {
                doSecondAction(1);
            }
        }
    }

    public override void doAction()
    {
        audioPlayer.volumeSwitchMute();
    }

    protected void doSecondAction(int value)
    {
        audioPlayer.volumeChangeVolume(value);
    }
}
