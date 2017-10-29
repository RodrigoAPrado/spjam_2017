using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

    protected LaneController laneController;
    protected GameObject presentWorld;
    protected GameObject futureWorld;

    protected int timesSpawnedInPresent;
    protected int timesSpawnedInFuture;

    protected int spawnInTopLane;
    protected int spawnInMidLane;
    protected int spawnInBotLane;

    protected string getSummonWorld()
    {

        string result = "";

        int chanceToSpawnInFuture = timesSpawnedInPresent + 1;

        int chanceToSpawnInPresent = timesSpawnedInFuture + 1;

        int totalChance = chanceToSpawnInFuture + chanceToSpawnInPresent;

        int rng = Random.Range(1, totalChance + 1);

        if (rng <= chanceToSpawnInPresent)
        {
            result = "present";
            timesSpawnedInPresent = timesSpawnedInPresent + 1;
        }
        else
        {
            result = "future";
            timesSpawnedInFuture = timesSpawnedInFuture + 1;
        }

        return result;
    }

    protected int getSummonLocation()
    {

        int result = 3;

        int totalValue = spawnInBotLane + spawnInMidLane + spawnInTopLane;

        if (totalValue == 0)
        {
            spawnInTopLane = 10;
            spawnInMidLane = 10;
            spawnInBotLane = 10;
            result = getSummonLocation();
        }

        if (totalValue > 0)
        {

            int rng = Random.Range(1, totalValue + 1);

            if (rng <= spawnInBotLane)
            {
                result = 0;
                spawnInBotLane = spawnInBotLane - 1;
            }
            else if (rng <= spawnInBotLane + spawnInMidLane)
            {
                result = 1;
                spawnInMidLane = spawnInMidLane - 1;
            }
            else
            {
                result = 2;
                spawnInTopLane = spawnInTopLane - 1;
            }

        }

        return result;
    }
}
