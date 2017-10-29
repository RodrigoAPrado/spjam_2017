using UnityEngine;
using System.Collections;

public class MarmotShootController : CharacterShootController {

    private EnemyMarmotController controller;

    private bool shot;

	// Use this for initialization
	void Start () {
        controller = GetComponent<EnemyMarmotController>();
        shot = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(controller.getCurrentState() == EnemyMarmotController.StateMachine.shoot && !shot)
        {
            shoot();
            shot = true;
        }
	}
}
