using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    TextMeshProUGUI damageText;

    private void Awake()
    {
        damageText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetDamageText(float amount)
    {
        damageText.text = amount.ToString();
    }

    public void DestroyText()
    {
        Destroy(this.gameObject);
    }
}
