using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AttributeType
{
    STRENGTH,
    DEXTERITY,
    INTELLIGENCE
}

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Create new stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Attributes")]
    public int Strength;
    public int Dexterity;
    public int Intelligence;
    public int AvailablePoints;


    [Header("Config")]
    public int CurrentLevel;

    [HideInInspector] public float TotalXP;
    [HideInInspector] public float TotalDamage;

    [Header("Attack")]
    public float BaseDamage;
    public float CriticalDamage;
    public float CriticalChance;


    [Header("Health")]
    public float CurrentHealth;
    public float MaxHealth;

    [Header("Mana")]
    public float CurrentMana;
    public float MaxMana;

    [Header("XP")]
    public float CurrentXP;
    public float NextLevelXP;
    public float InitialLevelXP;
    [Range(1f, 100f)]
    public float XPMultiplier;

    public void ResetPlayer()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
        CurrentLevel = 1;
        CurrentXP = 0f;
        NextLevelXP = InitialLevelXP;
        TotalXP = 0;
        BaseDamage = 2;
        CriticalChance = 10;
        CriticalDamage = 50;
        Strength = 0;
        Dexterity = 0;
        Intelligence = 0;
        AvailablePoints = 0;


    }
}
