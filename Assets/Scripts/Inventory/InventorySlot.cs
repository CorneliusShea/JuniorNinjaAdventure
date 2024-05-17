using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public static event Action<int> OnSlotSelected;
    public void UpdateSlot(InventoryItem item)
    {
        itemIcon.sprite = item.Icon;
        itemQty.text = item.Quantity.ToString();
    }

    public void ClickSlot()
    {
        OnSlotSelected?.Invoke(Index);
    }
}
