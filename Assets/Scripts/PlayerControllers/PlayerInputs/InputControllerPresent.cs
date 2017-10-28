using UnityEngine;
using System.Collections;

public class InputControllerPresent : InputController {

	// Use this for initialization
	void Start () {
        jumpButton = "PresentJump";
        shootButton = "PresentShoot";
        laneDownButton = "PresentLaneDown";
        laneUpButton = "PresentLaneUp";
        specialButton = "PresentSpecial";
        warpButton = "PresentWarp";
    }
}
