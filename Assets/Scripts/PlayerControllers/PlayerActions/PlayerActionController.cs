using UnityEngine;
using System.Collections;

public class PlayerActionController : IPlayerActionController {

    protected delegate void finishActionEventHandler();

    protected event finishActionEventHandler finishAction;

    public override void setStateController(PlayerStateController playerStateController)
    {
        this.playerStateController = playerStateController;
        setFinishAction();
    }

    protected override void setFinishAction()
    {

    }

    protected override void controlAction(bool action)
    {
        if (action)
        {
            if(actionTimer < 0)
                actionTimer = 0;
            if (actionTimer >= 0)
                actionTimer += Time.deltaTime;
            if (actionTimer > actionTimerEnd)
            {
                OnFinishAction();
                actionTimer = -1;
            }
        }
    }

    protected override bool checkAction()
    {
        return false;
    }

    protected override void OnFinishAction()
    {
        if (finishAction != null)
            finishAction();
    }
}
