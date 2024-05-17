using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] InventoryItem testItem;
    [SerializeField] InventoryItem[] inventoryItems;
    [SerializeField] int inventorySize;


    public int InventorySize => inventorySize;

    private void Start()
    {
        inventoryItems = new InventoryItem[inventorySize];
        CheckSlotForItem();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            AddItem(testItem, 1);
        }
    }

    public void AddItem(InventoryItem item, int quantity)
    {
        if (item == null || quantity == 0)
            return;

        List<int> itemIndexes = CheckItemStock(item.ID);

        if(item.IsStackable && itemIndexes.Count > 0)
        {
            foreach(int index in itemIndexes)
            {
                int currentMaxStack = item.MaxStack;

                if (inventoryItems[index].Quantity < currentMaxStack)
                {
                    inventoryItems[index].Quantity += quantity;

                    if (inventoryItems[index].Quantity > currentMaxStack)
                    {
                        int diff = inventoryItems[index].Quantity - currentMaxStack;
                        inventoryItems[index].Quantity = currentMaxStack;
                        AddItem(item, diff);
                    }

                    InventoryUI.i.DrawSlot(inventoryItems[index], index);
                    return;
                }
            }
        }

        int quantityToAdd = (quantity > item.MaxStack) ? item.MaxStack : quantity;
        AddItemToFreeSlot(item, quantityToAdd);

        int remainingAmout = quantity - quantityToAdd;
        if (remainingAmout > 0)
            AddItem(item, remainingAmout);
    }

    public void removeItem(int index)
    {
        if (inventoryItems[index] == null)
            return;

        inventoryItems[index] = null;
        InventoryUI.i.DrawSlot(null, index);
    }


    List<int>CheckItemStock(string itemID)
    {
        List<int> itemIndexes = new List<int>();
        for(int i = 0; i < inventoryItems.Length;i++)
        {
            if (inventoryItems[i] == null)
                continue;

            if (inventoryItems[i].ID == itemID)
            {
                itemIndexes.Add(i);
            }
            
        }

        return itemIndexes;
    }

    void AddItemToFreeSlot(InventoryItem item, int quantity)
    {
        for(int i = 0; i < inventorySize;i++)
        {
            if (inventoryItems[i] != null)
                continue;

            inventoryItems[i] = item.CreateItem();
            inventoryItems[i].Quantity = quantity;
            InventoryUI.DrawSlot(inventoryItems[i], i);
            return;
        }
    }

    void CheckSlotForItem()
    {
        for(int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] == null)
                InventoryUI.i.DrawSlot(null, i);
        }
    }


}
