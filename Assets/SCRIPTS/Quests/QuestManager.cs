using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private List<IQuest> activeQuests = new List<IQuest>();
    private List<IKillTracker> killTrackers = new List<IKillTracker>();
    private List<IFetchTracker> fetchTrackers = new List<IFetchTracker>();

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
        if (quest is IFetchTracker fetchTracker)
        {
            fetchTrackers.Add(fetchTracker);
        }

    }
    public void ReportExplore(string locationName)
    {
        foreach (var quest in activeQuests)
        {
            if (quest is ExploreQuest exploreQuest)
            {
                exploreQuest.ReportExplore(locationName);
            }
        }

        questUI?.UpdateUI();
    }

    public void ReportItemPickup(GameItem item)
    {
        foreach (var tracker in fetchTrackers)
        {
            tracker.RegisterItemPickup(item);
        }

        questUI?.UpdateUI();
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
