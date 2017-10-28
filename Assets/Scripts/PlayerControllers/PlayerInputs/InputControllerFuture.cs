using UnityEngine;
using System.Collections;

public class InputControllerFuture : InputController {

	// Use this for initialization
	void Start () {
        jumpButton = "FutureJump";
        shootButton = "FutureShoot";
        laneDownButton = "FutureLaneDown";
        laneUpButton = "FutureLaneUp";
        specialButton = "FutureSpecial";
        warpButton = "FutureWarp";
    }
}
