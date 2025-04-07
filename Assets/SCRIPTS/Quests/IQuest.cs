public interface IQuest
{
    string QuestName { get; }
    bool IsComplete { get; }
    void StartQuest();
}

public interface IKillTracker
{
    void RegisterKill();
}

public interface IQuestProgress
{
    int CurrentProgress { get; }
    int Goal { get; }
}
