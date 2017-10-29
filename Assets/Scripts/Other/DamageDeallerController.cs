using UnityEngine;
using System.Collections;

public class DamageDeallerController : MonoBehaviour {

    [SerializeField]
    private int damage = 8;

    void Start()
    {

    }

    public int getDamage()
    {
        return damage;
    }

}
