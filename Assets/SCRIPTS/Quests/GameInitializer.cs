using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;

    private void Start()
    {
        questManager.AddQuest(new ExploreQuest("Walk here", "Zone"));
        questManager.AddQuest(new FetchQuest("Find Axe", "Axe"));
        questManager.AddQuest(new FetchQuest("Find Potion", "Health Potion"));
        questManager.AddQuest(new KillQuest("Defeat 1 Enemies", 1));
        //var fetchQuest = new FetchQuest("Find the Axe", "Axe");
        //questManager.AddQuest(fetchQuest);

        //var killQuest = new KillQuest("Defeat Skeleton Zombie", 1);
        //questManager.AddQuest(killQuest);
        questManager = FindFirstObjectByType<QuestManager>();

    }
}
