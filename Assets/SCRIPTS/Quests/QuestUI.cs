using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private float completeDisplayDuration = 3f;

    private List<IQuest> allQuests = new List<IQuest>();
    private List<IQuest> displayedQuests = new List<IQuest>();

    public void SetQuest(IQuest quest)
    {
        allQuests.Add(quest);

        // Display if under the limit
        if (displayedQuests.Count < 2)
        {
            displayedQuests.Add(quest);
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        StartCoroutine(UpdateDisplayedQuests());
    }

    private IEnumerator UpdateDisplayedQuests()
    {
        for (int i = displayedQuests.Count - 1; i >= 0; i--)
        {
            var quest = displayedQuests[i];
            if (quest.IsComplete)
            {
                // Show complete status then remove after delay
                questText.text = GenerateQuestText();
                yield return new WaitForSeconds(completeDisplayDuration);

                displayedQuests.Remove(quest);
                break; // Only handle one at a time
            }
        }

        // Fill up quest slots if there are pending quests not yet shown
        foreach (var quest in allQuests)
        {
            if (!displayedQuests.Contains(quest) && !quest.IsComplete)
            {
                if (displayedQuests.Count < 2)
                {
                    displayedQuests.Add(quest);
                }
            }
        }

        questText.text = GenerateQuestText();
    }

    private string GenerateQuestText()
    {
        if (displayedQuests.Count == 0)
            return "No active quests.";

        string display = "";
        foreach (var quest in displayedQuests)
        {
            display += "\n";  // Add a newline before each quest for spacing
            if (quest.IsComplete)
            {
                display += $"{quest.QuestName} - <color=green>COMPLETE!</color>\n";
            }
            else if (quest is IQuestProgress progress)
            {
                display += $"{quest.QuestName} - {progress.CurrentProgress}/{progress.Goal}\n";
            }
            else
            {
                display += $"{quest.QuestName} - In Progress\n";
            }
        }

        return display.TrimEnd();
    }
}



//using TMPro;
//using UnityEngine;

//public class QuestUI : MonoBehaviour
//{
//    [SerializeField] private TextMeshProUGUI questText;

//    private IQuest currentQuest;
//    private IQuestProgress questProgress;

//    public void SetQuest(IQuest quest)
//    {
//        currentQuest = quest;
//        questProgress = quest as IQuestProgress;

//        UpdateUI(); // Initial display
//    }

//    public void UpdateUI()
//    {
//        if (currentQuest == null || questProgress == null) return;

//        if (currentQuest.IsComplete)
//        {
//            questText.text = $"{currentQuest.QuestName} - COMPLETE!";
//        }
//        else
//        {
//            questText.text = $"{currentQuest.QuestName} - {questProgress.CurrentProgress}/{questProgress.Goal}";
//        }
//    }
//}
