using UnityEngine;
using System.Collections;

public class CharacterDamageController : MonoBehaviour {

    protected CharacterHealthController characterHealthController;

    protected CharacterSpriteDamageController characterDamageSpriteController;

    protected GameController gameController;

    [SerializeField]
    protected Transform damageCollider;

    [SerializeField]
    protected LayerMask damageLayerMask;

    protected float damageHitBox = 0.6f;

    protected float damageCooldown;

    protected float startDamageCooldown = 0.4f;

    void Update()
    {
        if (damageCooldown > 0)
        {
            controlCooldown();
        }
        else
        {
            if (checkDamageAndDead())
            {
                gameController.execute("ok");
                GameObject.Destroy(gameObject);
            }
        }
    }

    protected void controlCooldown()
    {
        damageCooldown -= Time.deltaTime;
        characterDamageSpriteController.flicker();
        if (damageCooldown <= 0)
        {
            characterDamageSpriteController.halt();
        }
    }

    //Check if player should take damage and returns if player is dead or not after damage.
    protected virtual bool checkDamageAndDead()
    {
        int healthPoints = 1;
        Collider2D enemyHit = Physics2D.OverlapCircle(damageCollider.position, damageHitBox, damageLayerMask);
        if (enemyHit != null)
        {
            damageCooldown = startDamageCooldown;
        }
        if (healthPoints <= 0)
            return true;
        else
            return false;

    }

}
