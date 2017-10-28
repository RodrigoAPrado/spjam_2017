using UnityEngine;
using System.Collections;

public class EnemyHealthController : CharacterHealthController {

    [SerializeField]
    protected int maxHealthPoints;

    // Use this for initialization
    void Start ()
    {
        healthPoints = maxHealthPoints;
	}


}
