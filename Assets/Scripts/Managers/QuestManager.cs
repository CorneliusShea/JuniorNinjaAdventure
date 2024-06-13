using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    [SerializeField] Quest[] quests;
    [SerializeField] QuestCardNPC npcQuestCard;
    [SerializeField] Transform npcContainer;
    [SerializeField] QuestCardPlayer playerQuestCard;
    [SerializeField] Transform playerPanel;

    private void Start()
    {
        LoadQuestPanel();

        // DON'T LEAVE THIS IN
        ResetQuests();
    }
    void LoadQuestPanel()
    {
        for (int i = 0; i < quests.Length; i++)
        {
            QuestCard npcCard = Instantiate(npcQuestCard, npcContainer);
            npcCard.ConfigQuestUI(quests[i]);
        }
    }

    public void AcceptQuest(Quest quest)
    {
        QuestCardPlayer playerCard = Instantiate(playerQuestCard, playerPanel);
        playerCard.ConfigQuestUI(quest);
    }

    public void AddProgress(string questID, int amount)
    {
        Quest questToUpdate = DoesQuestExist(questID);

        if (questToUpdate == null)
            return;

        if(questToUpdate.QuestAccepted)
        {
            questToUpdate.AddProgress(amount);
        }
    }

    Quest DoesQuestExist(string questID)
    {
        foreach(Quest quest in quests)
        {
            if(quest.ID == questID)
                return quest;
        }

        return null;
    }

    void ResetQuests()
    {
        for(int i = 0; i < quests.Length;i++)
        {
            quests[i].ResetQuest();
        }
    }


}
