using UnityEngine;
using System.Collections;

public class PlayerJumpController : PlayerActionController
{

    void Start()
    {
        actionTimerEnd = 2;
    }

    void Update()
    {
        if (playerStateController != null)
            controlAction(checkAction());
    }

    protected override void setFinishAction()
    {
        finishAction += playerStateController.finishJump;
    }

    protected override bool checkAction()
    {
        PlayerStateController.StateMachine currentState = playerStateController.getCurrentState();
        if (currentState == PlayerStateController.StateMachine.jump ||
            currentState == PlayerStateController.StateMachine.jumpAndShooting ||
            currentState == PlayerStateController.StateMachine.jumpAndWarp)
            return true;
        else
            return false;
    }
}