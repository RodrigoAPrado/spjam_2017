using UnityEngine;
using System.Collections;

public class PlayerShootController : CharacterShootController {

    [SerializeField]
    private string type;

    private PlayerStateController playerStateController;

    private float baseMaxDelay = 0.5f;

    private float limitUpgradeMaxDelay = 0.2f;

    private float baseExplodeOverheat = 3;

    private float limitUpgradeExplodeOverheat = 6;

    private float explodeOverheat;

    private float overheat = 0;

    private float startCooldownOverheat = 3;

    private float cooldownOverheat = 0;

    [SerializeField]
    private GameObject warpBullet;

    private bool shotWarp;


    void Start()
    {


        bulletSpeed = 0.7f;

        if (type != "future" && type != "present")
        {
            throw new System.Exception("Invalid type. Type must be either future or present.");
        }

        setDelay();

        setOverheat();

        playerStateController = GetComponent<PlayerStateController>();
    }

    void Update()
    {
        /*Debug.Log("D: "+delay.ToString("F2") + "/" + maxDelay +
              " | OH: " + overheat.ToString("F2") + "/" + explodeOverheat + 
              " | CD: " + cooldownOverheat.ToString("F2") + "/" + startCooldownOverheat);*/
        if(playerStateController.getCurrentState() == PlayerStateController.StateMachine.warp ||
            playerStateController.getCurrentState() == PlayerStateController.StateMachine.jumpAndWarp)
        {
            if (!shotWarp)
            {
                shotWarp = true;
                GameObject b = shoot(warpBullet);

                b.GetComponent<BulletWarp>().setDimensionType(type);
            }
        }
        else
        {
            shotWarp = false;
        }
        if (playerStateController.getCurrentState() == PlayerStateController.StateMachine.shooting ||
            playerStateController.getCurrentState() == PlayerStateController.StateMachine.jumpAndShooting)
        {
            if(delay <= 0 && cooldownOverheat <= 0) { 
                shoot(bullet);
                overheat += maxDelay;
                if(overheat >= explodeOverheat)
                {
                    overheat = 0;
                    cooldownOverheat = startCooldownOverheat;
                }
                else
                {
                    delay = maxDelay;
                }
            }
        }

        if (cooldownOverheat > 0)
            controlCooldownOverheat();
        else if (delay > 0)
            controlDelay();
        else if (overheat > 0)
            controlOverheat();

    }

    protected override GameObject shoot(GameObject bullet = null)
    {
        if (bullet == null)
            bullet = this.bullet;

        GameObject b = GameObject.Instantiate(bullet,
                                            blastSpawner.position,
                                            bullet.transform.rotation) as GameObject;

        b.GetComponent<BulletController>().setSpeed(bulletSpeed);

        b.GetComponent<PlayerDamageDeallerController>().setType(type);

        return b;
    }

    private void setDelay()
    {
        if (PlayerPrefs.HasKey(type + "_shoot"))
        {
            maxDelay = baseMaxDelay - (0.1f * PlayerPrefs.GetInt(type + "_shoot"));
        }
        else
        {
            PlayerPrefs.SetInt(type + "_shoot", 0);
        }
    }

    private void setOverheat()
    {
        if (PlayerPrefs.HasKey(type + "_cooldown"))
        {
            explodeOverheat = baseExplodeOverheat + PlayerPrefs.GetInt(type + "_cooldown");
        }
        else
        {
            PlayerPrefs.SetInt(type + "_cooldown", 0);
        }
    }

    private void controlCooldownOverheat()
    {
        cooldownOverheat -= Time.deltaTime;
        if (cooldownOverheat < 0)
            cooldownOverheat = 0;
    }

    private void controlDelay()
    {
        delay -= Time.deltaTime;
        if (delay < 0)
            delay = 0;
    }

    private void controlOverheat()
    {
        overheat -= 0.5f * Time.deltaTime;
        if (overheat < 0)
            overheat = 0;
    }

    public void upgradeShoot()
    {
        maxDelay -= 0.1f;
        if (maxDelay < limitUpgradeMaxDelay)
            maxDelay = limitUpgradeMaxDelay;
    }

    public void upgradeCoolDown()
    {
        explodeOverheat = explodeOverheat + 1;
        if (explodeOverheat > limitUpgradeExplodeOverheat)
            explodeOverheat = limitUpgradeExplodeOverheat;
    }
}
