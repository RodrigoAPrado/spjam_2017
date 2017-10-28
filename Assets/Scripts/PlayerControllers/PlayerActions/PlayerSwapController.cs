using UnityEngine;
using System.Collections;

public class PlayerSwapController : PlayerActionController
{

    void Start()
    {
        actionTimerEnd = 1;
    }

    void Update()
    {
        if (playerStateController != null)
            controlAction(checkAction());
    }

    protected override void setFinishAction()
    {
        finishAction += playerStateController.finishSwap;
    }

    protected override bool checkAction()
    {
        PlayerStateController.StateMachine currentState = playerStateController.getCurrentState();
        if (currentState == PlayerStateController.StateMachine.swap)
            return true;
        else
            return false;
    }
}
