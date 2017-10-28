using UnityEngine;
using System.Collections;
using System;

public class InputController : IInputController {

    public override string recognizeInput()
    {
        if (Input.GetButtonDown(specialButton))
        {
            return "special";
        }
        else if (Input.GetButtonDown(jumpButton))
        {
            return "jump";
        }
        else if (Input.GetButtonDown(warpButton))
        {
            return "warp";
        }
        else if (Input.GetButtonDown(laneUpButton))
        {
            return "laneUp";
        }
        else if (Input.GetButtonDown(laneDownButton))
        {
            return "laneDown";
        }
        return "";
    }

    public override bool recognizeShooting()
    {
        if (Input.GetButton(shootButton))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
