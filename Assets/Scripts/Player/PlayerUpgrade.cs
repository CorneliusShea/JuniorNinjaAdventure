using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{
    public static event Action OnPlayerUpgrade;

    [SerializeField] UpgradeValues[] settings;
    [SerializeField] PlayerStats playerStats;

    private void Start()
    {
        AttributeButton.OnAttributePurchased += AttributePurchased;
    }

    private void AttributePurchased(AttributeType attributeType)
    {

        if (playerStats.AvailablePoints == 0) return;

        switch (attributeType)
        {
            case AttributeType.STRENGTH:
                UpgradePlayer(0);
                playerStats.Strength++;
                break;
            case AttributeType.DEXTERITY:
                UpgradePlayer(1);
                playerStats.Dexterity++;
                break;
            case AttributeType.INTELLIGENCE:
                UpgradePlayer(2);
                playerStats.Intelligence++;
                break;
        }

        playerStats.AvailablePoints--;
        OnPlayerUpgrade?.Invoke();


    }



    void UpgradePlayer(int index)
    {
        playerStats.BaseDamage += settings[index].DamageIncrease;
        playerStats.TotalDamage += settings[index].DamageIncrease;
        playerStats.MaxHealth += settings[index].HealthIncrease;
        playerStats.CurrentHealth += playerStats.MaxHealth;
        playerStats.MaxMana += settings[index].ManaIncrease;
        playerStats.CurrentMana += playerStats.MaxMana;
        playerStats.CriticalChance += settings[index].CChanceIncrease;
        playerStats.CriticalDamage += settings[index].CDamageIncrease;
    }


}

[System.Serializable]
public class UpgradeValues
{
    public string name;
    public float DamageIncrease;
    public float HealthIncrease;
    public float ManaIncrease;
    public float CChanceIncrease;
    public float CDamageIncrease;
}

