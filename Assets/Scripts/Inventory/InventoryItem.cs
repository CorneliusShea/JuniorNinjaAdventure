using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public enum ItemType
{
    WEAPON, POTION, SCROLL, INGREDIENTS, TREASUREs
}

[CreateAssetMenu(menuName = "Items/Item")]
public class InventoryItem : ScriptableObject
{

    public string ID;
    public string Name;
    public Sprite Icon;
    [TextArea] public string Description;

    public ItemType ItemType;

    public bool IsConsumable;
    public bool IsStackable;
    public int MaxStack;


    [HideInInspector] public int Quantity;

    public InventoryItem CopyItem()
    {
        InventoryItem item = Instantiate(this);
        return item;
    }

    public virtual bool UseItem()
    {
        return true;
    }
    public virtual void EquipItem()
    {

    }
    public virtual void RemoveItem()
    {

    }


}
