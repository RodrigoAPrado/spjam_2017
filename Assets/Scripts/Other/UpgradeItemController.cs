using UnityEngine;
using System.Collections;

public class UpgradeItemController : MonoBehaviour {

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string type;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

	// Update is called once per frame
	void Update ()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Stay"))
        {
            transform.Translate(new Vector2(-0.055f, 0));
        }
	}

    public string getType()
    {
        return type;
    }
}
