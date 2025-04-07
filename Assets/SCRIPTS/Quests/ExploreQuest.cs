using UnityEngine;

public class ExploreQuest : IQuest, IQuestProgress
{
    public string QuestName { get; private set; }
    public bool IsComplete { get; private set; }

    public int CurrentProgress => IsComplete ? 1 : 0;
    public int Goal => 1;

    private string targetLocationName;

    public ExploreQuest(string questName, string locationName)
    {
        QuestName = questName;
        targetLocationName = locationName;
        IsComplete = false;
    }

    public void StartQuest()
    {
        // Optional startup logic
    }

    public void ReportExplore(string exploredLocation)
    {
        if (!IsComplete && exploredLocation == targetLocationName)
        {
            IsComplete = true;
            Debug.Log($"ExploreQuest Complete: {QuestName}");
        }
    }

    public string TargetLocation => targetLocationName;
}
