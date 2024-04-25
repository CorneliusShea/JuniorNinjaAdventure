using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    MAGIC, MELEE
}

[CreateAssetMenu(fileName = "Weapon")]
public class Weapon : ScriptableObject
{
    public Sprite Icon;
    public WeaponType WeaponType;
    public float Damage;

    public Projectile ProjectilePrefab;
    public float RequiredMana;


}
