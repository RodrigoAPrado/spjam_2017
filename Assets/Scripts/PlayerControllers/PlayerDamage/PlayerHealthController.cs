using UnityEngine;
using System.Collections;

public class PlayerHealthController : CharacterHealthController
{

    protected int baseMaxHealthPoints = 100;
    
    protected int maxHealthPoints;

    protected int limitMaxHealthPoints = 255;

    protected int runtimeUpgradeValue = 20;

    protected int permanentUpgradeValue = 25;

    protected float recoverRate = 0.4f;

    void Start()
    {

    }

    protected void initializeHealth(string upgradeName)
    {
        maxHealthPoints = baseMaxHealthPoints + permanentUpgradeValue * PlayerPrefs.GetInt(upgradeName, 0);
        healthPoints = maxHealthPoints;
    }

    public void increaseHealthPoints(int value)
    {
        if (healthPoints + value > maxHealthPoints)
            healthPoints = maxHealthPoints;
        else
            healthPoints = healthPoints + value;
    }

    public void upgradeHealthPoint()
    {
        if(maxHealthPoints + runtimeUpgradeValue > limitMaxHealthPoints)
        {
            healthPoints = healthPoints + limitMaxHealthPoints - maxHealthPoints;
            maxHealthPoints = limitMaxHealthPoints;
        }
        else
        {
            maxHealthPoints = maxHealthPoints + runtimeUpgradeValue;
            healthPoints = healthPoints + runtimeUpgradeValue;
        }
    }

    public void recoverHealth()
    {
        int recoverValue = Mathf.RoundToInt(maxHealthPoints * recoverRate);

        if(healthPoints + recoverValue > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }
        else
        {
            healthPoints = healthPoints + recoverValue;
        }
    }

}
