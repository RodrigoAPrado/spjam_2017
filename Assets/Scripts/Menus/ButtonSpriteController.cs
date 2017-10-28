using UnityEngine;
using System.Collections;

public class ButtonSpriteController : IButtonSpriteController {

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        buttonSprite = Resources.Load<Sprite>("Sprites/TitleScreen/" + buttonSpriteName + "_sprite");

        if(buttonSprite != null) spriteRenderer.sprite = buttonSprite;

        buttonController = gameObject.GetComponent<Button>();
	}

    void Update()
    {
        if (buttonController.getSelected())
        {
            if (transform.localScale.x < 1.3f)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.1f,
                                                    transform.localScale.y + 0.1f,
                                                    transform.localScale.z + 0.1f);
            }
        }
        else
        {
            if (transform.localScale.x > 1)
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.1f,
                                                    transform.localScale.y - 0.1f,
                                                    transform.localScale.z - 0.1f);
            }
        }
    }

    public override void setButtonSpriteName(string name)
    {
        buttonSpriteName = name;
        changeSprite();
    }

    public override string getButtonSpriteName()
    {
        return buttonSpriteName;
    }

    protected override void changeSprite()
    {
        buttonSprite = Resources.Load<Sprite>("Sprites/TitleScreen/" + buttonSpriteName + "_sprite");
        if (buttonSprite != null) spriteRenderer.sprite = buttonSprite;
    }
}
