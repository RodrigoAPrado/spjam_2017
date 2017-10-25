using UnityEngine;
using System.Collections;

public class KeyboardButtonQuit : KeyboardButton {
    [SerializeField]

    public override void doAction()
    {
        Application.Quit();
    }
}
