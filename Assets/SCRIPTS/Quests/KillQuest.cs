using UnityEngine;
public class KillQuest : IQuest, IKillTracker, IQuestProgress
{
    public string QuestName { get; private set; }
    public int Goal { get; private set; }
    public int CurrentProgress { get; private set; }
    public bool IsComplete => CurrentProgress >= Goal;

    public KillQuest(string questName, int goal)
    {
        QuestName = questName;
        Goal = goal;
        CurrentProgress = 0;
    }

    public void StartQuest()
    {
        Debug.Log($"Started Kill Quest: {QuestName}");
    }

    public void RegisterKill()
    {
        if (!IsComplete)
        {
            CurrentProgress++;
            Debug.Log($"Kill Registered! {CurrentProgress}/{Goal}");

            if (IsComplete)
            {
                Debug.Log($"Kill Quest Complete: {QuestName}");
            }
        }
    }
}
