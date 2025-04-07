using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questText;

    private IQuest currentQuest;
    private IQuestProgress questProgress;

    public void SetQuest(IQuest quest)
    {
        currentQuest = quest;
        questProgress = quest as IQuestProgress;

        UpdateUI(); // Initial display
    }

    public void UpdateUI()
    {
        if (currentQuest == null || questProgress == null) return;

        if (currentQuest.IsComplete)
        {
            questText.text = $"{currentQuest.QuestName} - COMPLETE!";
        }
        else
        {
            questText.text = $"{currentQuest.QuestName} - {questProgress.CurrentProgress}/{questProgress.Goal}";
        }
    }
}
