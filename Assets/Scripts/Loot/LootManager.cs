using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LootManager : Singleton<LootManager>
{
    [SerializeField] GameObject lootPanel;
    [SerializeField] Transform container;
    [SerializeField] LootButton lootButton;


    bool IsLootPanelEmpty()
    {
        return container.childCount > 0;
    }

    public void ShowLoot(EnemyLoot enemyLoot)
    {
        lootPanel.SetActive(true);     // Step 3

        if (!IsLootPanelEmpty())       // Step 4
        {
            foreach (Transform child in container)  // Step 4a
            {
                Destroy(child.gameObject);
            }
        }

        foreach (DroppedItem item in enemyLoot.DroppedItems)  // Step 5
        {
            if (item.PickedItem)    // Step 5a
                continue;

            LootButton button = Instantiate(lootButton, container);  // Step 5b
            button.SetData(item);  // Step 5c
        }
    }

    public void ClosePanel()
    {
        print("called Close");
        lootPanel.SetActive(false);

    }



}


