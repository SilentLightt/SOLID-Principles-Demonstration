public interface IQuest
{
    string QuestName { get; }
    bool IsComplete { get; }
    void StartQuest();
}
public interface IFetchTracker
{
    void RegisterItemPickup(GameItem item);
}
public interface IFetchQuest : IQuestProgress
{
    string RequiredItemName { get; }
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
