//using UnityEngine;
//public class ExploreQuest : QuestBase, IExploreQuest
//{
//    private string targetArea;
//    private bool areaEntered;

//    public ExploreQuest(string name, string areaName) : base(name)
//    {
//        targetArea = areaName;
//        areaEntered = false;
//    }

//    public void OnAreaEntered(string areaName)
//    {
//        if (areaName == targetArea)
//        {
//            areaEntered = true;
//            CheckProgress();
//        }
//    }

//    public override void CheckProgress()
//    {
//        if (areaEntered && !IsCompleted)
//        {
//            IsCompleted = true;
//            Debug.Log($"{QuestName} completed! Explored {targetArea}.");
//        }
//    }
//}
