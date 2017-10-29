using UnityEngine;
using System.Collections;

public class LifeBarController : MonoBehaviour {

    [SerializeField]
    private PlayerHealthController futureCharacter;

    [SerializeField]
    private PlayerHealthController presentCharacter;

    [SerializeField]
    private Transform presentLifeBar;

    [SerializeField]
    private Transform presentLifeFrame;

    [SerializeField]
    private Transform futureLifeBar;

    [SerializeField]
    private Transform futureLifeFrame;
	
	// Update is called once per frame
	void Update () {
        presentLifeBar.localScale = new Vector2(presentLifeBar.localScale.x, 0.05f * presentCharacter.getCurrentHealth());
        presentLifeFrame.localScale = new Vector2(presentLifeFrame.localScale.x, 0.05f * presentCharacter.getMaxHealth());

        futureLifeBar.localScale = new Vector2(futureLifeBar.localScale.x, 0.05f * futureCharacter.getCurrentHealth());
        futureLifeFrame.localScale = new Vector2(futureLifeFrame.localScale.x, 0.05f * futureCharacter.getMaxHealth());
    }
}
