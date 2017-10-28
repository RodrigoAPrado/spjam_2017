using UnityEngine;
using System.Collections;

public class PlayerSpriteDamageController : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float alpha;

    private bool toAlpha;

    private float flickerRate;

    void Start()
    {
        alpha = 1;

        toAlpha = true;
    }

	public void flicker()
    {
        if (toAlpha)
        {
            if (alpha <= 0)
                toAlpha = false;
        }
        else
        {
            if (alpha >= 1)
                toAlpha = true;
        }
    }

    public void halt()
    {

    }

    public void initialize()
    {
        alpha = 1;

        toAlpha = true;
    }
}
