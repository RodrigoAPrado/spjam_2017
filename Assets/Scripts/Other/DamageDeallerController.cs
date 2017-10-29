using UnityEngine;
using System.Collections;

public class DamageDeallerController : MonoBehaviour {

    [SerializeField]
    private int damage = 8;

    [SerializeField]
    private bool low;

    [SerializeField]
    private bool high;

    void Start()
    {

    }

    public int getDamage()
    {
        return damage;
    }

}
