using UnityEngine;
using System.Collections;

public abstract class IInputController : MonoBehaviour {

    protected string jumpButton;
    protected string shootButton;
    protected string laneUpButton;
    protected string laneDownButton;
    protected string specialButton;
    protected string warpButton;

    public abstract string recognizeInput();

    public abstract bool recognizeShooting();
}
