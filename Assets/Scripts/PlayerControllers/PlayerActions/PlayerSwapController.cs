using UnityEngine;
using System.Collections;

public class PlayerSwapController : PlayerActionController
{

    PlayerLaneController playerLaneController;

    private int lastLaneValue;

    void Start()
    {
        playerLaneController = gameObject.GetComponent<PlayerLaneController>();
        actionTimerEnd = 1;
    }

    void Update()
    {
        if (playerStateController != null)
            controlAction(checkAction());
    }

    protected override void setFinishAction()
    {
        finishAction += this.changePlayerLane;
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

    public void checkAndSwapIfPossible(int value)
    {
        if (playerLaneController.checkLane(value))
        {
            lastLaneValue = value;
            playerStateController.changeStateToSwap();
        }
    }

    private void changePlayerLane()
    {
        playerLaneController.switchLane(lastLaneValue);
    }
}
