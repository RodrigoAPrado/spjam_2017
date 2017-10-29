using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDamageController : CharacterDamageController {

    [SerializeField]
    private string character;

    [SerializeField]
    private bool debug;

    // Use this for initialization
    void Start () {
        startDamageCooldown = 1.5f;
        damageCooldown = 0;
        characterHealthController = gameObject.GetComponent<PlayerHealthController>();
        characterDamageSpriteController = gameObject.GetComponent<PlayerSpriteDamageController>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameRuntimeController>();
    }

    void Update()
    {
        int healthPoints = 1;
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                healthPoints = characterHealthController.reduceHealthPoints(20);
                damageCooldown = startDamageCooldown;
                if (healthPoints <= 0)
                    gameController.execute(character + "Dead");
            }
        }
        if(damageCooldown > 0)
        {
            controlCooldown();
        }
        else
        {
            if (checkDamageAndDead())
                gameController.execute(character+"Dead");

                
        }
    }

    protected override int takeDamage(GameObject enemy)
    {

        int damage = enemy.GetComponent<DamageDeallerController>().getDamage();

        SelfDestructOnContact selfDestruct = enemy.GetComponent<SelfDestructOnContact>();

        if (selfDestruct != null)
            selfDestruct.destroySelf();

        return characterHealthController.reduceHealthPoints(damage);
    }
}
