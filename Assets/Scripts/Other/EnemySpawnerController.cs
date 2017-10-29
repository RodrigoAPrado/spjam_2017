using UnityEngine;
using System.Collections;

public class EnemySpawnerController : MonoBehaviour {
    
    private LaneController laneController;
    private GameObject presentWorld;
    private GameObject futureWorld;

    [SerializeField]
    private GameObject[] futureEnemies;

    [SerializeField]
    private GameObject[] pastEnemies;

    [SerializeField]
    private float[] ratio;

    private int enemiesInFuture;
    private int enemiesInPresent;
    private int enemiesFromFuture;
    private int enemiesFromPresent;
    private int enemiesInTopLane;
    private int enemiesInMidLane;
    private int enemiesInBotLane;


    private ScoreController scoreController;

    private float spawnTimerMax = 6;

    private float spawnTimer;

    private int scoreCheck = 5;

    // Use this for initialization
    void Start () {
        enemiesInFuture = 0;
        enemiesInPresent = 0;
        enemiesFromFuture = 0;
        enemiesFromPresent = 0;
        enemiesInTopLane = 10;
        enemiesInMidLane = 10;
        enemiesInBotLane = 10;
        spawnTimer = 0;
        laneController = GameObject.FindGameObjectWithTag("LaneController").GetComponent<LaneController>();
        scoreController = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreController>();
        presentWorld = GameObject.FindGameObjectWithTag("PresentWorld");
        futureWorld = GameObject.FindGameObjectWithTag("FutureWorld");
    }

    void Update()
    {
        
        string world = getSummonWorld();
        string dimension = getSummonEnemyDimension();
        //getSummonEnemyType();
        int location = getSummonLocation();

        summonAnEnemy(world, dimension, location);
    }

    private string getSummonWorld()
    {

        string result =  "";

        int chanceToSpawnInFuture = enemiesInPresent + 1;

        int chanceToSpawnInPresent = enemiesInFuture + 1;

        int totalChance = chanceToSpawnInFuture + chanceToSpawnInPresent;

        int rng = Random.Range(1, totalChance + 1);

        if(rng <= chanceToSpawnInPresent)
        {
            result = "present";
            enemiesInPresent = enemiesInPresent + 1;
        }
        else
        {
            result = "future";
            enemiesInFuture = enemiesInFuture + 1;
        }

        return result;
    }

    private string getSummonEnemyDimension()
    {
        string result = "";

        int chanceToSpawnFromFuture = enemiesFromPresent + 1;

        int chanceToSpawnFromPresent = enemiesFromFuture + 1;

        int totalChance = chanceToSpawnFromFuture + chanceToSpawnFromPresent;

        int rng = Random.Range(1, totalChance + 1);

        if (rng <= chanceToSpawnFromPresent)
        {
            result = "present";
            enemiesFromPresent = enemiesFromPresent + 1;
        }
        else
        {
            result = "future";
            enemiesFromFuture = enemiesFromFuture + 1;
        }

        return result;
    }

    private int getSummonLocation()
    {

        int result = 3;

        int totalValue = enemiesInBotLane + enemiesInMidLane + enemiesInTopLane;

        if(totalValue == 0)
        {
            enemiesInTopLane = 10;
            enemiesInMidLane = 10;
            enemiesInBotLane = 10;
            result = getSummonLocation();
        }

        if (totalValue > 0)
        {

            int rng = Random.Range(1, totalValue + 1);

            if (rng <= enemiesInBotLane)
            {
                result = 0;
                enemiesInBotLane = enemiesInBotLane - 1;
            }
            else if (rng <= enemiesInBotLane + enemiesInMidLane)
            {
                result = 1;
                enemiesInMidLane = enemiesInMidLane - 1;
            }
            else
            {
                result = 2;
                enemiesInTopLane = enemiesInTopLane - 1;
            }

        }

        return result;
    }

    private void summonAnEnemy(string world, string dimension, int location)
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

        GameObject[] enemyRoster = null;
        switch (dimension)
        {
            case "present":
                enemyRoster = pastEnemies;
                break;
            case "future":
                enemyRoster = futureEnemies;
                break;
        }

        if(world == "future")
        {
            location += 3;
        }

        Vector2 spawnPosition = new Vector2(10, laneController.getLanePositionStart(location));

        GameObject enemy = GameObject.Instantiate(enemyRoster[0], spawnPosition, enemyRoster[0].transform.rotation) as GameObject;

        //worldToSummon.transform.GetChild()
    }

    public int getTotalEnemies()
    {
        return enemiesFromFuture + enemiesFromPresent;
    }

    
}
