using UnityEngine;
using System.Collections;

public class SelfDestructOnContact : MonoBehaviour {

	
    public void destroySelf()
    {
        GameObject.Destroy(this.gameObject);
    }
}
