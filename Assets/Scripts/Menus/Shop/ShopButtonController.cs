using UnityEngine;
using System.Collections;

public class ShopButtonController : MonoBehaviour {

    private Button[] menuButtons;
    private int currentButton;

    // Use this for initialization
    void Start() {
        menuButtons = new Button[11];

        Button[] menuButtonsA = GameObject.FindGameObjectWithTag("PresentShop").
                                        GetComponentsInChildren<ButtonUpgrade>();

        Button[] menuButtonsB = GameObject.FindGameObjectWithTag("FutureShop").
                                        GetComponentsInChildren<ButtonUpgrade>();

        Button buttonBack = GameObject.FindGameObjectWithTag("BackButton").GetComponent<Button>();

        menuButtonsA.CopyTo(menuButtons, 0);
        menuButtonsB.CopyTo(menuButtons, menuButtonsA.Length);

        menuButtons[10] = buttonBack;

        currentButton = 0;

        menuButtons[currentButton].switchSelected();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Up"))
        {
            menuButtons[currentButton].switchSelected();
            changeButtonUp();
            menuButtons[currentButton].switchSelected();
        }
        else if (Input.GetButtonDown("Down"))
        {
            menuButtons[currentButton].switchSelected();
            changeButtonDown();
            menuButtons[currentButton].switchSelected();
        }
        else if (Input.GetButtonDown("Left"))
        {
            menuButtons[currentButton].switchSelected();
            changeButtonLeft();
            menuButtons[currentButton].switchSelected();
        }
        else if (Input.GetButtonDown("Right"))
        {
            menuButtons[currentButton].switchSelected();
            changeButtonRight();
            menuButtons[currentButton].switchSelected();
        }
    }

    private void changeButtonUp()
    {
        if (currentButton == 0 || currentButton == 5)
            currentButton = menuButtons.Length - 1;
        else if (currentButton == menuButtons.Length - 1)
            currentButton = (menuButtons.Length - 1) / 2 - 1;
        else
            currentButton--;
    }

    private void changeButtonDown()
    {
        if (currentButton == menuButtons.Length - 1)
            currentButton = 0;
        else if (currentButton == (menuButtons.Length - 1)/2-1)
            currentButton = menuButtons.Length - 1;
        else
            currentButton++;
    }

    private void changeButtonLeft()
    {
        if (currentButton == menuButtons.Length - 1)
            currentButton--;
        else if (currentButton - 5 < 0)
            currentButton = currentButton + 5;
        else
            currentButton = currentButton - 5;
    }

    private void changeButtonRight()
    {
        if (currentButton == menuButtons.Length - 1)
            currentButton--;
        else if (currentButton + 5 > menuButtons.Length - 1)
            currentButton = currentButton - 5;
        else
            currentButton = currentButton + 5;
    }
}
