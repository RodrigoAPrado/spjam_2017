using UnityEngine;
using System.Collections;

public class PlayerWarpController : PlayerActionController {

    void Start()
    {
        actionTimerEnd = 0.5f;
    }

    void Update()
    {
        if (playerStateController != null)
            controlAction(checkAction());
    }

    protected override void setFinishAction()
    {
        finishAction += playerStateController.finishWarp;
    }

    protected override bool checkAction()
    {
        PlayerStateController.StateMachine currentState = playerStateController.getCurrentState();
        if (currentState == PlayerStateController.StateMachine.warp ||
            currentState == PlayerStateController.StateMachine.jumpAndWarp)
            return true;
        else
            return false;
    }
}
