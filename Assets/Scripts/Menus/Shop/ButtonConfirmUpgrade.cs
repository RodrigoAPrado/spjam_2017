using UnityEngine;
using System.Collections;

public class ButtonConfirmUpgrade : ButtonConfirm {

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("UpgradeController").GetComponent<GameController>();
        command = "";
        sceneToLoad = "Shop";
    }

}
