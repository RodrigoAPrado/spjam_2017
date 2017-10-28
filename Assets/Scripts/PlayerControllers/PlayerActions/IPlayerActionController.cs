using UnityEngine;
using System.Collections;

public abstract class IPlayerActionController : MonoBehaviour {

    protected PlayerStateController playerStateController;

    protected float actionTimerEnd;

    protected float actionTimer = -1;

    public abstract void setStateController(PlayerStateController playerStateController);

    protected abstract void setFinishAction();

    protected abstract void controlAction(bool action);

    protected abstract bool checkAction();

    protected abstract void OnFinishAction();
}
