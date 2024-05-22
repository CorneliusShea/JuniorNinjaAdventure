using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapon", fileName = "Item_Weapon")]
public class Item_Weapon : InventoryItem
{
    public Weapon Weapon;

    public override void EquipItem()
    {
        WeaponManager.i.EquipWeapon(Weapon);
    }
}
