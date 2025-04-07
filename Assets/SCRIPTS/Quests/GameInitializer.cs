using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;

    private void Start()
    {
        var killQuest = new KillQuest("Defeat 1 Enemies", 1);
        questManager.AddQuest(killQuest);
        questManager = FindFirstObjectByType<QuestManager>();

    }
}
