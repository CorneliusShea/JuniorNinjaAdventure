using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats/Create new stats")]
public class PlayerStats : ScriptableObject
{
    public int CurrentLevel;

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
    }
}
