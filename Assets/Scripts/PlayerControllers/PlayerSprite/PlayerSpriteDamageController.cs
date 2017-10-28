using UnityEngine;
using System.Collections;

public class PlayerSpriteDamageController : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float alpha;

    private bool toAlpha;

    private float flickerRate = 20;

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

    private void initialize()
    {
        alpha = 1;

        toAlpha = true;

        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
