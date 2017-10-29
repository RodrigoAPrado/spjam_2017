using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {


    private float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(speed, 0));
        if(transform.position.x > 13 || transform.position.x < -13)
        {
            GameObject.Destroy(gameObject);
        }
	}

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public virtual void effect(GameObject target)
    {

    }
}
