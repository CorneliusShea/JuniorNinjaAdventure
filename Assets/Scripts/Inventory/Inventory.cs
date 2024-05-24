using BayatGames.SaveGameFree;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] InventoryItem testItem;
    [SerializeField] InventoryItem[] inventoryItems;
    [SerializeField] int inventorySize;

    [SerializeField] GameContent gameContent;


    public int InventorySize => inventorySize;

    private readonly string INVENTORY_KEY_DATA = "MY_INVENTORY";

    public InventoryItem[] InventoryItems => inventoryItems;

    private void Start()
    {
        inventoryItems = new InventoryItem[inventorySize];
        CheckSlotForItem();
        LoadInventory();
        //SaveGame.Delete(INVENTORY_KEY_DATA);

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


        List<int> itemIdexes = CheckItemStock(item.ID);

        if (item.IsStackable && itemIdexes.Count > 0)    
        {
            foreach (int index in itemIdexes)    
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
                    SaveInventory();
                    return;
                }
            }
        }

        int quantityToAdd = quantity > item.MaxStack ? item.MaxStack : quantity;
        AddItemToFreeSlot(item, quantityToAdd);
        int remainingAmount = quantity - quantityToAdd;
        if (remainingAmount > 0)
            AddItem(item, remainingAmount);

        SaveInventory();
    }

    public void RemoveItem(int index)
    {
        if (inventoryItems[index] == null) return;


        inventoryItems[index].RemoveItem();
        inventoryItems[index] = null;
        InventoryUI.i.DrawSlot(null, index);

        SaveInventory();
    }



    List<int> CheckItemStock(string itemID)
    {
        List<int> itemIndexes = new List<int>();
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i] == null) continue;
            if (inventoryItems[i].ID == itemID)
            {
                itemIndexes.Add(i);
            }
        }
        return itemIndexes;
    }


    void AddItemToFreeSlot(InventoryItem item, int quantity)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (inventoryItems[i] != null) continue;

            inventoryItems[i] = item.CopyItem();     
            inventoryItems[i].Quantity = quantity;
            InventoryUI.i.DrawSlot(inventoryItems[i], i); 
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

    

    void DecreaseItem(int index)
    {
        inventoryItems[index].Quantity--;

        if (inventoryItems[index].Quantity <= 0)
        {
            inventoryItems[index] = null;
            InventoryUI.i.DrawSlot(null, index);
        }
        else
        {
            InventoryUI.i.DrawSlot(inventoryItems[index], index);
        }

    }

    public void UseItem(int index)
    {
        if (inventoryItems[index] == null) return;

        if (inventoryItems[index].UseItem())
        {
            DecreaseItem(index);
        }

        SaveInventory();
    }

    public void EquipItem(int index)
    {
        if (inventoryItems[index] == null)
            return;
        if (inventoryItems[index].ItemType != ItemType.WEAPON)
            return;

        inventoryItems[index].EquipItem();
    }

    void SaveInventory()
    {
        InventoryData saveData = new InventoryData();
        saveData.ItemContent = new string[inventorySize];
        saveData.ItemQuantity = new int[inventorySize];

        for(int i = 0; i < inventorySize; i++)
        {
            InventoryItem currItem = inventoryItems[i];
            if (currItem == null)
            {
                saveData.ItemContent[i] = null;
                saveData.ItemQuantity[i] = 0;
            }
            else
            {
                saveData.ItemContent[i] = currItem.ID;
                saveData.ItemQuantity[i] = currItem.Quantity;
            }
        }

        SaveGame.Save(INVENTORY_KEY_DATA, saveData);


    }

    InventoryItem ItemInGameContent(string itemID)
    {
        for(int i = 0 ; i < inventorySize; i++)
        {
            if (gameContent.GameItems[i].ID == itemID)
            {
                return gameContent.GameItems[i];
            }
        }

        return null;
    }

    void LoadInventory()
    {
        if(SaveGame.Exists(INVENTORY_KEY_DATA))
        {
            InventoryData loadData = SaveGame.Load<InventoryData>(INVENTORY_KEY_DATA);

            for(int i = 0; i < inventorySize; i++)
            {
                if (loadData.ItemContent[i] != null)
                {
                    InventoryItem itemFromContent = ItemInGameContent(loadData.ItemContent[i]);

                    if(itemFromContent != null)
                    {
                        inventoryItems[i] = itemFromContent.CopyItem();
                        inventoryItems[i].Quantity = loadData.ItemQuantity[i];
                        InventoryUI.i.DrawSlot(inventoryItems[i], i);
                    }
                    else
                    {
                        inventoryItems[i] = null;
                    }
                }
            }
        }
    }

    


}
