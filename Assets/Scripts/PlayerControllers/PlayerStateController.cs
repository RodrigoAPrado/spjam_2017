using UnityEngine;
using System.Collections;

public class PlayerStateController : MonoBehaviour {

    private IInputController inputController;

    private PlayerJumpController playerJumpController;
    private PlayerSwapController playerSwapController;
    private PlayerWarpController playerWarpController;

    [HideInInspector] public enum StateMachine
    {
        normal,
        shooting,
        warp,
        swap,
        jump,
        jumpAndShooting,
        jumpAndWarp
    }

    private StateMachine currentState;

    void Start()
    {
        currentState = StateMachine.normal;
        inputController = gameObject.GetComponent<IInputController>();

        playerJumpController = gameObject.GetComponent<PlayerJumpController>();
        playerJumpController.setStateController(this);

        playerSwapController = gameObject.GetComponent<PlayerSwapController>();
        playerSwapController.setStateController(this);

        playerWarpController = gameObject.GetComponent<PlayerWarpController>();
        playerWarpController.setStateController(this);
    }

    void Update()
    {
        //Debug.Log(this.gameObject+"/"+currentState);

        checkInputShoot(inputController.recognizeShooting());

        checkInputOther();

    }

    private void changeCurrentState(StateMachine state)
    {
        currentState = state;
    }

    private void checkInputOther()
    {
        switch (inputController.recognizeInput())
        {
            case "special":
                changeStateToSpecial();
                break;
            case "jump":
                changeStateToJump();
                break;
            case "warp":
                changeStateToWarp();
                break;
            case "laneUp":
                changeStateToSwap(1);
                break;
            case "laneDown":
                changeStateToSwap(-1);
                break;
            default:
                break;
        }
    }

    private void checkInputShoot(bool isShooting)
    {
        if (isShooting)
        {
            switch (currentState)
            {
                case StateMachine.normal:
                    changeCurrentState(StateMachine.shooting);
                    break;
                case StateMachine.jump:
                    changeCurrentState(StateMachine.jumpAndShooting);
                    break;
            }
        }
        else
        {
            switch (currentState)
            {
                case StateMachine.shooting:
                    changeCurrentState(StateMachine.normal);
                    break;
                case StateMachine.jumpAndShooting:
                    changeCurrentState(StateMachine.jump);
                    break;
            }
        }
    }

    private void changeStateToSpecial()
    {
        throw new System.NotImplementedException("Not Implemented");
    }

    private void changeStateToWarp()
    {
        switch (currentState)
        {
            case StateMachine.normal:
                changeCurrentState(StateMachine.warp);
                break;
            case StateMachine.shooting:
                changeCurrentState(StateMachine.warp);
                break;
            case StateMachine.jump:
                changeCurrentState(StateMachine.jumpAndWarp);
                break;
            case StateMachine.jumpAndShooting:
                changeCurrentState(StateMachine.jumpAndWarp);
                break;
        }
    }

    private void changeStateToJump()
    {
        switch (currentState)
        {
            case StateMachine.normal:
                changeCurrentState(StateMachine.jump);
                break;
            case StateMachine.shooting:
                changeCurrentState(StateMachine.jumpAndShooting);
                break;
            case StateMachine.warp:
                changeCurrentState(StateMachine.jumpAndWarp);
                break;
        }
    }

    private void changeStateToSwap(int lane)
    {
        switch (currentState)
        {
            case StateMachine.normal:
                changeCurrentState(StateMachine.swap);
                break;
            case StateMachine.shooting:
                changeCurrentState(StateMachine.swap);
                break;
        }
    }

    public StateMachine getCurrentState()
    {
        return currentState;
    }

    public void finishJump()
    {
        if (currentState == StateMachine.jumpAndWarp)
            changeCurrentState(StateMachine.warp);
        else
            changeCurrentState(StateMachine.normal);
    }

    public void finishWarp()
    {
        if (currentState == StateMachine.jumpAndWarp)
            changeCurrentState(StateMachine.jump);
        else
            changeCurrentState(StateMachine.normal);
    }

    public void finishSwap()
    {
        changeCurrentState(StateMachine.normal);
    }
}
