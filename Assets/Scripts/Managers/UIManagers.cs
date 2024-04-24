using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagers : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    [Header("Player UI Bars")]
    [SerializeField] Image healthBar;
    [SerializeField] Image manaBar;
    [SerializeField] Image xpBar;

    [Header("Player UI Text")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] TextMeshProUGUI xpText;


    private void Update()
    {
        UpdatePlayerUI();
    }

    void UpdatePlayerUI()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerStats.CurrentHealth / playerStats.MaxHealth, 10f * Time.deltaTime);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, playerStats.CurrentHealth / playerStats.MaxMana, 10f * Time.deltaTime);
        xpBar.fillAmount = Mathf.Lerp(xpBar.fillAmount, playerStats.CurrentXP / playerStats.NextLevelXP, 10f * Time.deltaTime);

        levelText.text = $"Level {playerStats.CurrentLevel}";
        healthText.text = $"{playerStats.CurrentHealth} / {playerStats.MaxHealth}";
        manaText.text = $"{playerStats.CurrentMana} / {playerStats.MaxMana}";
        xpText.text = $"{playerStats.CurrentXP} / {playerStats.NextLevelXP}";
    }

}
