using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : Singleton<WeaponManager>
{
    [SerializeField] Image weaponIcon;
    [SerializeField] TextMeshProUGUI weaponMana;

    public void EquipWeapon(Weapon weapon)
    {
        weaponIcon.sprite = weapon.Icon;
        weaponIcon.gameObject.SetActive(true);
        weaponMana.text = weapon.RequiredMana.ToString();
        weaponMana.gameObject.SetActive(true);

        GameManager.i.PlayerData.PlayerAttack.EquipWeapon(weapon);

        weaponIcon.SetNativeSize();

    }




}
