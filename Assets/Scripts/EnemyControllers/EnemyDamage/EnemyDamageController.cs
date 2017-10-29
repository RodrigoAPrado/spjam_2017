using UnityEngine;
using System.Collections;

public class EnemyDamageController : CharacterDamageController {

    void Start()
    {
        value = "1";
        damageCooldown = 0;
        characterHealthController = gameObject.GetComponent<CharacterHealthController>();
        characterDamageSpriteController = gameObject.GetComponent<CharacterSpriteDamageController>();
        gameController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
    }
}
