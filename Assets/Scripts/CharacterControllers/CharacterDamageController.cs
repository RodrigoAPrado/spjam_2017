using UnityEngine;
using System.Collections;

public class CharacterDamageController : MonoBehaviour {

    protected CharacterHealthController characterHealthController;

    protected CharacterSpriteDamageController characterDamageSpriteController;

    protected GameController gameController;

    protected string value = "";

    [SerializeField]
    protected Transform damageCollider;

    [SerializeField]
    protected LayerMask damageLayerMask;

    [SerializeField]
    private string type;

    protected float damageHitBox = 0.6f;

    protected float damageCooldown;

    protected float startDamageCooldown = 0.4f;

    void Start()
    {
        if(type != "future" || type != "present")
        {
            throw new System.Exception("Type Invalid. Must be either future or present");
        }
    }

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
                gameController.execute(value);
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
    protected bool checkDamageAndDead()
    {
        int healthPoints = 1;
        Collider2D enemyHit = Physics2D.OverlapCircle(damageCollider.position, damageHitBox, damageLayerMask);
        if (enemyHit != null)
        {
            damageCooldown = startDamageCooldown;
            healthPoints = takeDamage(enemyHit.gameObject);
        }
        if (healthPoints <= 0)
            return true;
        else
            return false;

    }

    protected virtual int takeDamage(GameObject enemy)
    {
        PlayerDamageDeallerController damage = enemy.GetComponent<PlayerDamageDeallerController>();

        BulletController bullet = enemy.GetComponent<BulletController>();

        if (bullet != null)
            bullet.effect(this.gameObject);

        SelfDestructOnContact selfDestruct = enemy.GetComponent<SelfDestructOnContact>();

        if (selfDestruct != null)
            selfDestruct.destroySelf();

        int boost = string.Equals(type, damage.getTypeOfDamage()) ? 3 : 1;

        return characterHealthController.reduceHealthPoints(damage.getDamage() * boost);
    }

}
