using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<IQuest> activeQuests = new List<IQuest>();
    private List<IKillTracker> killTrackers = new List<IKillTracker>();

    [SerializeField] private QuestUI questUI;

    public void AddQuest(IQuest quest)
    {
        activeQuests.Add(quest);
        quest.StartQuest();

        if (quest is IKillTracker killTracker)
        {
            killTrackers.Add(killTracker);
        }

        if (questUI != null)
        {
            questUI.SetQuest(quest);
        }
    }

    public void ReportKill()
    {
        foreach (var tracker in killTrackers)
        {
            tracker.RegisterKill();
        }

        // Update UI after all kill events
        questUI?.UpdateUI();
    }
}
