using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_HealthPotion", menuName = "Items/Health Potion")]
public class Item_HealthPotion : InventoryItem
{
    public float HealthRestored;

    public override bool UseItem()
    {
        if (GameManager.i.PlayerData.PlayerHealth.CanRestoreHealth())
        {
            GameManager.i.PlayerData.PlayerHealth.RestoreHealth(HealthRestored);
            return true;
        }

        return false;
    }
}
