using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : Singleton<DamageManager>
{
    [SerializeField] DamagePopup damagePopupPrefab;

    public void ShowDamageText(float damageAmount, Transform parent)
    {
        DamagePopup go = Instantiate(damagePopupPrefab, parent);
        go.transform.position += Vector3.right * 0.5f;
        go.SetDamageText(damageAmount);
    }
}
