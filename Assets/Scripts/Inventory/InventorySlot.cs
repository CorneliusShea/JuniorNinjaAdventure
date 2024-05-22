using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public static event Action<int> OnSlotSelected;

    [SerializeField] Image itemIcon;
    [SerializeField] Image qtyImage;
    [SerializeField] TextMeshProUGUI itemQty;

    public int Index { get; set; }
    public void UpdateSlot(InventoryItem item)
    {
        itemIcon.sprite = item.Icon;
        itemQty.text = item.Quantity.ToString();
        itemIcon.SetNativeSize();
    }

    public void ClickSlot()
    {
        OnSlotSelected?.Invoke(Index);
    }

    public void ShowSlotInformation(bool value)
    {
        itemIcon.gameObject.SetActive(value);
        qtyImage.gameObject.SetActive(value);
    }
}
