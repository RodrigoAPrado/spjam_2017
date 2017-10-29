using UnityEngine;
using System.Collections;

public class MarmotDamageController : EnemyDamageController {

    private EnemyMarmotController controller;



    void Start()
    {
        controller = GetComponent<EnemyMarmotController>();
        value = "4";
        damageCooldown = 0;
        characterHealthController = gameObject.GetComponent<CharacterHealthController>();
        characterDamageSpriteController = gameObject.GetComponent<CharacterSpriteDamageController>();
        gameController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
    }

    void Update()
    {
        if (damageCooldown > 0)
        {
            controlCooldown();
        }
        else
        {
            if (controller.getCurrentState() != EnemyMarmotController.StateMachine.hidden &&
                controller.getCurrentState() != EnemyMarmotController.StateMachine.appear &&
                controller.getCurrentState() != EnemyMarmotController.StateMachine.hide) {
                if (checkDamageAndDead())
                {
                    gameController.execute(value);
                    GameObject.Destroy(gameObject);
                }
            }
        }
    }

}
