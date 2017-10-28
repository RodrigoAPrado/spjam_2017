using UnityEngine;
using System.Collections;

public class ButtonBack : ButtonChangePage {
    void Update()
    {
        if (selected && !disabled)
        {
            if (Input.GetButtonDown("Submit"))
            {
                doAction();
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            doAction();
        }
    }
}
