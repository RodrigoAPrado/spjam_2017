using UnityEngine;
using System.Collections;

public class CharacterHealthController : MonoBehaviour {

    protected int healthPoints;

    void Start()
    {
        
    }

    public int reduceHealthPoints(int value)
    {
        if (healthPoints - value < 0)
            healthPoints = 0;
        else
            healthPoints = healthPoints - value;

        return healthPoints;
    }

}
