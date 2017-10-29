using UnityEngine;
using System.Collections;

public class PlayerSwapController : PlayerActionController
{

    PlayerLaneController playerLaneController;

    private int lastLaneValue;

    private float baseActionTimerEnd = 0.8f;

    private float limitActionTimerEnd = 0.2f;

    [SerializeField]
    private string character;

    void Start()
    {
        if(character != "future" && character != "present")
        {
            throw new System.Exception("Invalid character. Character must be either future or present");
        }

        playerLaneController = gameObject.GetComponent<PlayerLaneController>();

        setActionTimerEnd();
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

    private void setActionTimerEnd()
    {
        if (PlayerPrefs.HasKey(character + "_lane"))
        {
            actionTimerEnd = baseActionTimerEnd - 0.2f * PlayerPrefs.GetInt(character + "_lane");
        }
        else
        {
            actionTimerEnd = baseActionTimerEnd;
            PlayerPrefs.SetInt(character + "_lane", 0);
        }
    }

    public void upgradeSwapSpeed()
    {
        actionTimerEnd -= 0.2f;
        if (actionTimerEnd < limitActionTimerEnd)
            actionTimerEnd = limitActionTimerEnd;
    }
}
