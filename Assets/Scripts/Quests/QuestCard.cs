using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestCard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questName;
    [SerializeField] TextMeshProUGUI questDescription;

    public Quest QuestToComplete { get; set; }

    public virtual void ConfigQuestUI(Quest quest)
    {
        QuestToComplete = quest;
        questName.text = quest.Name;
        questDescription.text = quest.Description;
    }
}


