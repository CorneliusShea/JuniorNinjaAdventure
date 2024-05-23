using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LootButton : MonoBehaviour
{
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemQuantity;

    public DroppedItem LoadedItem { get; private set; }

    public void SetData(DroppedItem droppedItem)
    {
        LoadedItem = droppedItem;
        itemIcon.sprite = droppedItem.Item.Icon;
        itemName.text = droppedItem.Item.Name;
        itemQuantity.text = droppedItem.Quantity.ToString();
    }

    public void CollectItem()
    {
        if (LoadedItem == null)
            return;

        Inventory.i.AddItem(LoadedItem.Item, LoadedItem.Quantity);
        LoadedItem.PickedItem = true;
        Destroy(gameObject);
    }

}

