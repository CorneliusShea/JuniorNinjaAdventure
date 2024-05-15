using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int inventorySize = 10;
    public int InventorySize => inventorySize;

    private void Start()
    {
        inventoryItems = new InventoryItem[inventorySize];
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            AddItem(testItem, 15);
        }
    }

    void AddItem(InventoryItem item, int quantity)
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
                        int diff = inventroyItems[index].Quantity - currentMaxStack;
                        inventoryItems[index].Quantity = currentMaxStack;
                        AddItem(item, diff);
                    }

                    InventoryUI.i.DrawSlot(inventoryItems[index], index);
                }
            }
        }

        int quantityToAdd = (quantity > item.MaxStack) ? item.MaxStack : quantity;
        AddItemToFreeSlot(item, quantityToAdd);

        int remainingAmout = quantity - quantityToAdd;
        if (remainingAmout > 0)
            AddItem(item, remainingAmout);
    }







    List<int>CheckItemStock(string itemID)
    {
        List<int> itemIndexes = new List<int>();
        for(int i = 0; i < InventoryItems.Length;i++)
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


}
