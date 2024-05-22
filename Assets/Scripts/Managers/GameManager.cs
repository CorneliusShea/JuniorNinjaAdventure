using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] PlayerData playerData;

    public PlayerData PlayerData 
    {  
        get { return playerData; } 
    }

    public void AddPlayerXP(float xpAmount)
    {
        PlayerXP playerXP = playerData.GetComponent<PlayerXP>();
        playerXP.AddXP(xpAmount);
    }


}
