using UnityEngine;
using System.Collections;

public class KeyboardButton : Button {

    void Update()
    {
        if (selected)
        {   
            if (Input.GetButtonDown("Confirm"))
            {
                doAction();
            }
        }
    }

    public override void doAction()
    {
        
    }

    public override bool getSelected()
    {
        return selected;
    }
}
