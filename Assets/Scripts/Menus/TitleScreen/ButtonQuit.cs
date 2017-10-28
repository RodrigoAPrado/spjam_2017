using UnityEngine;
using System.Collections;

public class ButtonQuit : Button {

    public override void doAction()
    {
        Application.Quit();
    }
}
