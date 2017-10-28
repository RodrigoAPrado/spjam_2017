using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDamageController : MonoBehaviour {

    private PlayerHealthController playerHealthController;

    private PlayerSpriteDamageController playerDamageSpriteController;

    private GameRuntimeController gameRuntimeController;

    [SerializeField]
    private Transform damageCollider;

    [SerializeField]
    private LayerMask enemyLayerMask;

    [SerializeField]
    private string character;

    [SerializeField]
    private bool debug;

    private float damageCooldown;

    private float startDamageCooldown = 1.5f;

    private float damageHitBox = 0.6f;

	// Use this for initialization
	void Start () {
        damageCooldown = 0;
        playerHealthController = gameObject.GetComponent<PlayerHealthController>();
        playerDamageSpriteController = gameObject.GetComponent<PlayerSpriteDamageController>();
        gameRuntimeController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameRuntimeController>();
    }

    void Update()
    {
        int healthPoints = 1;
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                healthPoints = playerHealthController.reduceHealthPoints(20);
                damageCooldown = startDamageCooldown;
                if (healthPoints <= 0)
                    gameRuntimeController.execute(character + "Dead");
            }
        }
        if(damageCooldown > 0)
        {
            controlCooldown();
        }
        else
        {
            if (checkDamageAndDead())
                gameRuntimeController.execute(character+"Dead");

                
        }
    }

    private void controlCooldown()
    {
        damageCooldown -= Time.deltaTime;
        playerDamageSpriteController.flicker();
        if(damageCooldown <= 0)
        {
            playerDamageSpriteController.halt();
        }
    }

    //Check if player should take damage and returns if player is dead or not after damage.
    private bool checkDamageAndDead()
    {
        int healthPoints = 1;
        Collider2D enemyHit = Physics2D.OverlapCircle(damageCollider.position, damageHitBox, enemyLayerMask);
        if (enemyHit != null)
        {
            damageCooldown = startDamageCooldown;
            //Implement getting enemyDamageValue
            //healthPoints = playerHealthController.reduceHealthPoints(enemyHit.gameObject.GetComponent<>);
        }
        if (healthPoints <= 0)
            return true;
        else
            return false;

    }
}
