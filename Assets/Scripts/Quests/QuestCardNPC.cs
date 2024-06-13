using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestCardNPC : QuestCard
{
    [SerializeField] TextMeshProUGUI questReward;

    public override void ConfigQuestUI(Quest quest)
    {
        base.ConfigQuestUI(quest);
        questReward.text = $"- {quest.GoldReward} Gold\n" +
                            $"- {quest.XPReward} XP\n" +
                            $"- x{quest.ItemReward.Quantity}{quest.ItemReward.Item.Name}";
    }

    public void AcceptQuest()
    {
        if (QuestToComplete == null) 
            return;

        QuestToComplete.QuestAccepted = true;
        QuestManager.i.AcceptQuest(QuestToComplete);
        gameObject.SetActive(false); 
    }

}

