using UnityEngine;
using System.Collections;

public class ButtonSpriteController : MonoBehaviour {

    [SerializeField]
    private string buttonSpriteName;
    private Sprite buttonSprite;
    private SpriteRenderer spriteRenderer;
    private Button buttonController;

	// Use this for initialization
	void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        buttonSprite = Resources.Load<Sprite>("Sprites/Title_Screen/" + buttonSpriteName + "_sprite");

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
}
