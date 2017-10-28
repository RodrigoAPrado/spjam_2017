using UnityEngine;
using System.Collections;

public class ButtonBackToMainMenu : ButtonChangePage {

    void Start()
    {
        sceneToLoad = "TitleScreen";
    }

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
