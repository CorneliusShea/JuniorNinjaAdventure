using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    List<InventorySlot> slotList = new List<InventorySlot>();
    public InventorySlot CurrentSlot { get; set; }

    private void Start()
    {
        InitInventory();
        InventorySlot.OnSlotSelected += SlotSelected;
    }
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }

    void SlotSelected(int index)
    {
        CurrentSlot = slotList[index];
    }

    public void RemoveItem()
    {
        if(CurrentSlot == null)
            return;

        Inventory.i.RemoveItem(CurrentSlot.Index);
    }

    public void DrawSlot(Inventory item, int index)
    {
        InventorySlot slot = slotIndex[index];

        if (item ==null)
        {
            InventorySlot.ShowSlotInformation(false);
            return;
        }
       
        slot.ShowSlotInformation(true);
        slot.UpdateSlot(item);

    }
}
