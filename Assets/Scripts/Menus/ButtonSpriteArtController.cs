using UnityEngine;
using System.Collections;

public class ButtonSpriteArtController : ButtonSpriteController {

    private Sprite buttonSpriteSelected;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        buttonSprite = Resources.Load<Sprite>("Sprites/TitleScreen/" + buttonSpriteName);

        buttonSpriteSelected = Resources.Load<Sprite>("Sprites/TitleScreen/" + buttonSpriteName + "_selected");

        if (buttonSprite != null) spriteRenderer.sprite = buttonSprite;

        buttonController = gameObject.GetComponent<Button>();
    }
	
	// Update is called once per frame
	void Update () {
        if (buttonController.getSelected())
        {
            if (buttonSpriteSelected != null) changeSelected(buttonSpriteSelected);
        }
        else
        {
            if (buttonSprite != null) changeSelected(buttonSprite);
        }
    }

    private void changeSelected(Sprite currentSprite)
    {
        spriteRenderer.sprite = currentSprite;
    }

    protected override void changeSprite()
    {
        buttonSprite = Resources.Load<Sprite>("Sprites/TitleScreen/" + buttonSpriteName);
        buttonSpriteSelected = Resources.Load<Sprite>("Sprites/TitleScreen/" + buttonSpriteName + "_selected");
        if (buttonSprite != null) spriteRenderer.sprite = buttonSprite;
    }
}
