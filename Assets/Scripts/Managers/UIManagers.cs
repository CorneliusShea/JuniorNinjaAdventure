using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagers : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] GameObject statsPanel;
    [SerializeField] TextMeshProUGUI statLevel;
    [SerializeField] TextMeshProUGUI statDamage;
    [SerializeField] TextMeshProUGUI statCChance;
    [SerializeField] TextMeshProUGUI statCDamage;
    [SerializeField] TextMeshProUGUI statTotalXP;
    [SerializeField] TextMeshProUGUI statCurrentXP;
    [SerializeField] TextMeshProUGUI statNextLevelXP;

    [Header("Player UI Bars")]
    [SerializeField] Image healthBar;
    [SerializeField] Image manaBar;
    [SerializeField] Image xpBar;

    [Header("Player UI Text")]
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI manaText;
    [SerializeField] TextMeshProUGUI xpText;

    [Header("Player UI Attributes")]
    [SerializeField] TextMeshProUGUI availablePoints;
    [SerializeField] TextMeshProUGUI strength;
    [SerializeField] TextMeshProUGUI dexterity;
    [SerializeField] TextMeshProUGUI intelligence;

    [Header("Quest Panel")]
    [SerializeField] GameObject npcQuestPanel;
    [SerializeField] GameObject playerQuestPanel;



    private void Start()
    {
        PlayerUpgrade.OnPlayerUpgrade += PlayerUpgraded;
        DialogManager.OnExtraInteraction += HandleExtraInteraction;
    }

    void PlayerUpgraded()
    {
        UpdateStatsPanel();
    }


    private void Update()
    {
        UpdatePlayerUI();
    }

    void UpdatePlayerUI()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerStats.CurrentHealth / playerStats.MaxHealth, 10f * Time.deltaTime);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, playerStats.CurrentMana / playerStats.MaxMana, 10f * Time.deltaTime);
        xpBar.fillAmount = Mathf.Lerp(xpBar.fillAmount, playerStats.CurrentXP / playerStats.NextLevelXP, 10f * Time.deltaTime);

        levelText.text = $"Level {playerStats.CurrentLevel}";
        healthText.text = $"{playerStats.CurrentHealth} / {playerStats.MaxHealth}";
        manaText.text = $"{playerStats.CurrentMana} / {playerStats.MaxMana}";
        xpText.text = $"{playerStats.CurrentXP} / {playerStats.NextLevelXP}";
    }


    void UpdateStatsPanel()
    {
        statLevel.text = playerStats.CurrentLevel.ToString();
        statDamage.text = playerStats.BaseDamage.ToString();
        statCChance.text = playerStats.CriticalChance.ToString();
        statCDamage.text = playerStats.CriticalDamage.ToString();
        statTotalXP.text = playerStats.TotalXP.ToString();
        statCurrentXP.text = playerStats.CurrentXP.ToString();
        statNextLevelXP.text = playerStats.NextLevelXP.ToString();


        availablePoints.text = $"Points: {playerStats.AvailablePoints}";
        strength.text = playerStats.Strength.ToString();
        dexterity.text = playerStats.Dexterity.ToString();
        intelligence.text = playerStats.Intelligence.ToString();


    }

    public void ToggleStatsPanel()
    {
        statsPanel.SetActive(!statsPanel.activeSelf);
        if (statsPanel.activeSelf)
        {
            UpdateStatsPanel();
        }
    }

    void HandleExtraInteraction(InteractionType type) 
    {
        switch (type) 
        {
            case InteractionType.Quest:
                ToggleNPCQuestPanel(true);
                break;

            case InteractionType.Shop:
                break;

        }
    }

    public void ToggleNPCQuestPanel(bool value)
    {
        npcQuestPanel.SetActive(value);
    }

    public void TogglePlayerQuestPanel()
    {
        playerQuestPanel.SetActive(!playerQuestPanel.activeSelf);
    }






}
