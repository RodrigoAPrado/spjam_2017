using UnityEngine;
using System.Collections;

public class BulletWarp : BulletController {

    private string type;
    public void setDimensionType(string type)
    {
        this.type = type;
    }

    public override void effect(GameObject target)
    {
        EnemyBaseController enemy = target.GetComponent<EnemyBaseController>();

        int lane = enemy.getLane();

        if(lane >= 3)
        {
            lane = lane - 3;
        }
        else
        {
            lane = lane + 3;
        }

        enemy.switchLane(lane);
    }

}
