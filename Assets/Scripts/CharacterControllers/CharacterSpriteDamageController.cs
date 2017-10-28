using UnityEngine;
using System.Collections;

public class CharacterSpriteDamageController : MonoBehaviour {
    [SerializeField]
    protected SpriteRenderer spriteRenderer;

    protected float alpha;

    protected bool toAlpha;

    protected float flickerRate = 20;

    void Start()
    {
        initialize();
    }

    public void flicker()
    {
        if (toAlpha)
        {
            alpha -= flickerRate * Time.deltaTime;
            if (alpha <= 0)
                toAlpha = false;
        }
        else
        {

            alpha += flickerRate * Time.deltaTime;
            if (alpha >= 0.5f)
                toAlpha = true;
        }

        spriteRenderer.color = new Color(1, 1, 1, alpha);
    }

    public void halt()
    {
        initialize();
    }

    protected void initialize()
    {
        alpha = 1;

        toAlpha = true;

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
