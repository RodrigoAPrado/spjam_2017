using UnityEngine;
using System.Collections;
using System;

public class UpgradeSetter : GameController {

    public override void execute(string command)
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            throw new Exception("Invalid score value");
        }
        command = PlayerPrefs.GetString("upgradePower");
        string price = PlayerPrefs.GetString("upgradePrice");

        if (command == "" || price == "")
        {
            throw new System.Exception("Invalid power upgrade name.");
        }

        if (!PlayerPrefs.HasKey(command))
        {
            PlayerPrefs.SetInt(command, 1);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - Int32.Parse(price));            
        }
        else if (PlayerPrefs.GetInt(command) < 3)
        {
            PlayerPrefs.SetInt(command, PlayerPrefs.GetInt(command) + 1);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") - Int32.Parse(price));
        }
        else
        {
            throw new System.Exception("Invalid value for power upgrade. Power upgrade cannot go beyond 3.");
        }
    }
}
