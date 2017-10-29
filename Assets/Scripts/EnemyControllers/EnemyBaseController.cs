using UnityEngine;
using System.Collections;

public class EnemyBaseController : MonoBehaviour {

    protected int currentLane;

    protected LaneController laneController;

    void Start()
    {
        laneController = GameObject.FindGameObjectWithTag("LaneController").GetComponent<LaneController>();
    }

    public void setLane(int lane)
    {
        currentLane = lane;
    }

    public int getLane()
    {
        return currentLane;
    }

    public void switchLane(int lane)
    {
        setLane(lane);
        gameObject.transform.position = new Vector2(transform.position.x, laneController.getLanePositionStart(lane));
    }

}
