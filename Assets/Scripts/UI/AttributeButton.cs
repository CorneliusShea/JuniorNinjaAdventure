using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButton : MonoBehaviour
{
    public static event Action<AttributeType> OnAttributePurchased;

    [SerializeField] AttributeType attribute;

    public void PurchaseAttribute()
    {
        OnAttributePurchased?.Invoke(attribute);
    }
}
