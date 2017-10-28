using UnityEngine;
using System.Collections;
using System;

public class Button : IButton {

    void Update()
    {
        if (selected && !disabled)
        {   
            if (Input.GetButtonDown("Submit"))
            {
                doAction();
            }
        }
    }

    public override bool getSelected()
    {
        return selected;
    }

    public override void switchSelected()
    {
        selected = !selected;
    }

    public override bool getDisabled()
    {
        return disabled;
    }

    public override void doAction()
    {

    }
}
