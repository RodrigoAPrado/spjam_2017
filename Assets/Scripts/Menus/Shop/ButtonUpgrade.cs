using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonUpgrade : ButtonConfirm {

    private UpgradeManager upgradeManager;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("UpgradeController").GetComponent<UpgradeGetter>();
        upgradeManager = GetComponent<UpgradeManager>();
    }

    public override void doAction()
    {
        if (upgradeManager.canBuy() && upgradeManager.getRank() < 3)
        {
            command = upgradeManager.getUpgradeCommandName();
            gameController.execute(command);
            SceneManager.LoadScene("ConfirmUpgrade");
        }
    }
}
