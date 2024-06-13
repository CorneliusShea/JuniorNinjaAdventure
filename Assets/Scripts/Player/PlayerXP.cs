using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    private void Awake()
    {
        
    }

    public void AddXP(float amount)
    {
        playerStats.TotalXP += amount;       
        playerStats.CurrentXP += amount;

        while (playerStats.CurrentXP >= playerStats.NextLevelXP)
        {
            playerStats.CurrentXP -= playerStats.NextLevelXP;
            NextLevel();
        }
    }

    void NextLevel()
    {
        playerStats.CurrentLevel++;
        playerStats.AvailablePoints++;


        var currXPRequired = playerStats.NextLevelXP;
        var newNextLevelXP = Mathf.Round(currXPRequired + playerStats.NextLevelXP * (playerStats.XPMultiplier / 100f));

        playerStats.NextLevelXP = newNextLevelXP;
    }
}
