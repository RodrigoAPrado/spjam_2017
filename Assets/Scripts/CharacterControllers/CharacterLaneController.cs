using UnityEngine;
using System.Collections;

public class CharacterLaneController : MonoBehaviour {

    protected int currentLane;

    protected LaneMovementController laneMovementController;
    protected LaneController laneController;

    [SerializeField]
    protected string character;

    protected int laneModifier;

    void Start()
    {
        currentLane = 0;

        laneMovementController = gameObject.GetComponent<LaneMovementController>();
        laneController = GameObject.FindGameObjectWithTag("LaneController").GetComponent<LaneController>();

        if (character == "future")
        {
            laneModifier = 4;
        }
        else if (character == "present")
        {
            laneModifier = 1;
        }
        else
        {
            throw new System.Exception("Character value invalid. Must be either future or present");
        }
    }

    public void switchLane(int value)
    {
        if (value != -1 && value != 1)
        {
            throw new System.Exception("Invalid value. New lane value must be either 1 or -1");
        }
        currentLane += value;


        float height = laneController.getLanePositionStart(currentLane + laneModifier);
        Vector2 targetLane = new Vector2(-7, height);

        laneMovementController.setTarget(targetLane);
        laneMovementController.finishMovement();
    }

    public bool checkLane(int value)
    {
        if (value != -1 && value != 1)
        {
            throw new System.Exception("Invalid value. New lane value must be either 1 or -1");
        }

        if (value == 1)
        {
            if (currentLane + value > 1)
                return false;
            else
                return true;
        }
        else
        {
            if (currentLane + value < -1)
                return false;
            else
                return true;
        }
    }
}
