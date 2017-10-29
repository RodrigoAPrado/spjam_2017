using UnityEngine;
using System.Collections;

public class PlayerUpgradeController : MonoBehaviour {

    [SerializeField]
    private LayerMask upgradeLayerMask;
    
    private float hitBox = 0.7f;

    [SerializeField]
    protected Transform upgardeCollider;

    private PlayerHealthController playerHealthController;

    private PlayerShootController playerShootController;

    private PlayerSwapController playerSwapController;

    void Start()
    {
        playerHealthController = GetComponent<PlayerHealthController>();

        playerShootController = GetComponent<PlayerShootController>();

        playerSwapController = GetComponent<PlayerSwapController>();
    }
	
	// Update is called once per frame
	void Update () {
        string upgrade = checkUpgrade();

        switch (upgrade)
        {
            case "hpregen":
                playerHealthController.recoverHealth();
                break;
            case "hpup":
                playerHealthController.upgradeHealthPoint();
                break;
            case "cooldown":
                playerShootController.upgradeCoolDown();
                break;
            case "lane":
                playerSwapController.upgradeSwapSpeed();
                break;
            case "shoot":
                playerShootController.upgradeShoot();
                break;
        }
	}

    protected string checkUpgrade()
    {
        string result = "";
        Collider2D hit = Physics2D.OverlapCircle(upgardeCollider.position, hitBox, upgradeLayerMask);
        if(hit != null)
        {
            result = hit.gameObject.GetComponent<UpgradeItemController>().getType();
            hit.gameObject.GetComponent<SelfDestructOnContact>().destroySelf();
        }

        return result;

    }
}
