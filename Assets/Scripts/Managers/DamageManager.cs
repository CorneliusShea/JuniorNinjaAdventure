using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager i;
    [SerializeField] DamagePopup damagePopupPrefab;


    private void Awake()
    {
        i = this;
    }

    public void ShowDamageText(float damageAmount, Transform parent)
    {
        DamagePopup go = Instantiate(damagePopupPrefab, parent);
        go.transform.position += Vector3.right * 0.5f;
        go.SetDamageText(damageAmount);
    }
}
