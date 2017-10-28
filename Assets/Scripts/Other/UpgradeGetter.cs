using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpgradeGetter : GameController {

    public override void execute(string command)
    {
        string[] upgrade = command.Split('$');
        PlayerPrefs.SetString("upgradePower", upgrade[0]);
        PlayerPrefs.SetString("upgradePrice", upgrade[1]);

    }
}
