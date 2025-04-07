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
