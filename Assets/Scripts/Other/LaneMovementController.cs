using UnityEngine;
using System.Collections;

public class LaneMovementController : MonoBehaviour {

    protected Vector2 target;

    public void setTarget(Vector2 target)
    {
        this.target = target;
    }

    public void finishMovement()
    {
        gameObject.transform.position = target;
    }
}
