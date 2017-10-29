using UnityEngine;
using System.Collections;

public class UpgradeSpawnerController : SpawnerController {

    private EnemySpawnerController enemySpawner;

    [SerializeField]
    private GameObject pomba;

    private int ratio;

    private int maxRatio;

    private int[] upgradeSeed;

    [SerializeField]
    private bool debug;

    private bool spawned;

    [SerializeField]
    private GameObject[] upgradeItems;

    // Use this for initialization
    void Start () {
        upgradeSeed = new int[] {0,0,0,
                                 1,1,1,
                                 2,2,
                                 3,3,
                                 4,4};
        maxRatio = 64;
        timesSpawnedInFuture = 0;
        timesSpawnedInPresent = 0;
        ratio = 16;
        enemySpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawnerController>();
        presentWorld = GameObject.FindGameObjectWithTag("PresentWorld");
        futureWorld = GameObject.FindGameObjectWithTag("FutureWorld");
        laneController = GameObject.FindGameObjectWithTag("LaneController").GetComponent<LaneController>();
    }

    void Update()
    {
        if(enemySpawner.getTotalEnemies() % 5 == 0)
        {
            if ((checkUpgrade() || debug) && !spawned)
            {
                string world = getSummonWorld();
                int location = getSummonLocation();
                int type = getUpgradeType();
                spawnUpgrade(world, location, type);
                spawned = true;
            }
        }
        else
        {
            spawned = false;
        }
    }

    private void spawnUpgrade(string world, int location, int type)
    {

        GameObject worldToSummon = null;
        switch (world)
        {
            case "present":
                worldToSummon = presentWorld;
                break;
            case "future":
                worldToSummon = futureWorld;
                break;
        }

        if (world == "future")
        {
            location += 3;
        }

        GameObject upgrade = upgradeItems[type];

        Vector2 spawnPosition = new Vector2(10, laneController.getLanePositionStart(location));

        GameObject p = GameObject.Instantiate(pomba, spawnPosition, pomba.transform.rotation) as GameObject;

        p.GetComponent<UpgradeController>().setUpgrade(upgrade);

        p.transform.SetParent(worldToSummon.transform.GetChild(1).transform);

    }

    private int getUpgradeType()
    {
        int result = 0;
        int max = upgradeSeed.Length;
        int rng = Random.Range(1, max);

        result = upgradeSeed[rng];

        return result;
    }

    private bool checkUpgrade()
    {
        bool result = false;
        int rng = Random.Range(1,101);

        if(rng <= ratio)
        {
            result = true;
            resetRatio();
        }
        else
        {
            increaseRatio();
        }

        return result;
    }

    private void resetRatio()
    {
        ratio = 1;
    }

    private void increaseRatio()
    {
        ratio = ratio * 2;
        if (ratio > maxRatio)
            ratio = maxRatio;
    }
}
