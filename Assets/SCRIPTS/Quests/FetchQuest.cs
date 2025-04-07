using UnityEngine;
using System.Collections;
public class FetchQuest : IQuest, IFetchTracker, IFetchQuest
{
    public string QuestName { get; private set; }
    public bool IsComplete { get; private set; } = false;
    public int CurrentProgress { get; private set; } = 0;
    public int Goal => 1;
    public string RequiredItemName { get; private set; }

    public FetchQuest(string questName, string requiredItemName)
    {
        QuestName = questName;
        RequiredItemName = requiredItemName;
    }

    public void StartQuest()
    {
        Debug.Log($"{QuestName} started. Find and pick up {RequiredItemName}.");
    }

    public void RegisterItemPickup(GameItem item)
    {
        if (IsComplete) return;

        if (item.ItemName == RequiredItemName)
        {
            CurrentProgress = 1;
            IsComplete = true;
            Debug.Log($"{QuestName} complete! You picked up {RequiredItemName}.");
        }
    }
}


//using UnityEngine;
//public class FetchQuest : QuestBase, IFetchQuest
//{
//    private string targetItemName;
//    private bool itemCollected;

//    public FetchQuest(string name, string itemName) : base(name)
//    {
//        targetItemName = itemName;
//        itemCollected = false;
//    }

//    public void OnItemPicked(GameItem item)
//    {
//        if (item.ItemName == targetItemName)
//        {
//            itemCollected = true;
//            CheckProgress();
//        }
//    }

//    public override void CheckProgress()
//    {
//        if (itemCollected && !IsCompleted)
//        {
//            IsCompleted = true;
//            Debug.Log($"{QuestName} completed! Collected {targetItemName}.");
//        }
//    }
//}
