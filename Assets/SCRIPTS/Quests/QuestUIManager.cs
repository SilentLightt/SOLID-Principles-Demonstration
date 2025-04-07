using System.Collections.Generic;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    //[SerializeField] private GameObject questEntryPrefab;
    //[SerializeField] private Transform questListParent;

    //private Dictionary<IQuest, QuestUIEntry> _questEntries = new();

    //public void AddQuest(IQuest quest)
    //{
    //    GameObject go = Instantiate(questEntryPrefab, questListParent);
    //    var uiEntry = go.GetComponent<QuestUIEntry>();

    //    _questEntries.Add(quest, uiEntry);
    //    UpdateQuestDisplay(quest);
    //}

    //public void UpdateQuestDisplay(IQuest quest)
    //{
    //    if (!_questEntries.ContainsKey(quest)) return;

    //    string progress = GetProgressText(quest);
    //    _questEntries[quest].SetQuestInfo(quest.Title, progress, quest.IsComplete);
    //}

    //private string GetProgressText(IQuest quest)
    //{
    //    // Extend for other types
    //    if (quest is KillQuest kq)
    //        return $"Killed {kq.CurrentKills}/{kq.TargetKills}";

    //    if (quest is FetchQuest fq)
    //        return $"Collected {fq.CurrentCount}/{fq.RequiredCount}";

    //    if (quest is ExploreQuest eq)
    //        return eq.IsComplete ? "Explored!" : "Not visited";

    //    return "In progress";
    //}
}
