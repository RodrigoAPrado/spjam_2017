using UnityEngine;
using System.Collections;

public class CharacterShootController : MonoBehaviour {

    [SerializeField]
    protected GameObject bullet;

    [SerializeField]
    protected Transform blastSpawner;

    [SerializeField]
    protected float bulletSpeed;

    protected float delay;

    protected float maxDelay;

    protected virtual void shoot()
    {
        GameObject b = GameObject.Instantiate(bullet, 
                                            blastSpawner.position, 
                                            bullet.transform.rotation) as GameObject;

        b.GetComponent<BulletController>().setSpeed(bulletSpeed);
    }
}
