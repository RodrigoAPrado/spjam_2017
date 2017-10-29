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

    //Check if player should take damage and returns if player is dead or not after damage.
    protected override bool checkDamageAndDead()
    {
        int healthPoints = 1;
        Collider2D enemyHit = Physics2D.OverlapCircle(damageCollider.position, damageHitBox, damageLayerMask);
        if (enemyHit != null)
        {
            damageCooldown = startDamageCooldown;
            Debug.Log("ok");
            //Implement getting enemyDamageValue
            //healthPoints = playerHealthController.reduceHealthPoints(enemyHit.gameObject.GetComponent<>);
        }
        if (healthPoints <= 0)
            return true;
        else
            return false;

    }
}
