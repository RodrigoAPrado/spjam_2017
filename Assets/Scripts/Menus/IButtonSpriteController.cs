using UnityEngine;
using System.Collections;

public abstract class IButtonSpriteController : MonoBehaviour
{

    [SerializeField]
    protected string buttonSpriteName;
    protected Sprite buttonSprite;
    protected SpriteRenderer spriteRenderer;
    protected Button buttonController;

    public abstract void setButtonSpriteName(string name);

    public abstract string getButtonSpriteName();

    protected abstract void changeSprite();
}
