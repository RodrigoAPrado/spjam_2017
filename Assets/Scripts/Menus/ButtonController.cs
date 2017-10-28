using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    private Button[] menuButtons;
    private int currentButton;

	// Use this for initialization
	void Start () {
        currentButton = 0;
        menuButtons = gameObject.GetComponentsInChildren<Button>();
        menuButtons[currentButton].switchSelected();
    }

    void Update()
    {
        if (Input.GetButtonDown("Up") || Input.GetButtonDown("Left"))
        {
            menuButtons[currentButton].switchSelected();
            changeButtonUp();
            menuButtons[currentButton].switchSelected();
        }
        else if (Input.GetButtonDown("Down") || Input.GetButtonDown("Right"))
        {
            menuButtons[currentButton].switchSelected();
            changeButtonDown();
            menuButtons[currentButton].switchSelected();
        }
    }

    private void changeButtonUp()
    {
        if (currentButton == 0)
            currentButton = menuButtons.Length - 1;
        else
            currentButton--;
        if (menuButtons[currentButton].getDisabled())
            changeButtonUp();
    }

    private void changeButtonDown()
    {
        if (currentButton == menuButtons.Length - 1)
            currentButton = 0;
        else
            currentButton++;
        if (menuButtons[currentButton].getDisabled())
            changeButtonDown();
    }
}
