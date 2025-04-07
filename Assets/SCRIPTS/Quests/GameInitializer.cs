using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private QuestManager questManager;
    //[SerializeField] private EnemySpawner enemySpawner;

    private void Start()
    {
        questManager = FindFirstObjectByType<QuestManager>();
        //enemySpawner = FindAnyObjectByType<EnemySpawner>();

        questManager.AddQuest(new ExploreQuest("Walk Past the Red Walls", "Zone"));
        questManager.AddQuest(new FetchQuest("Find Axe", "Axe"));
        questManager.AddQuest(new FetchQuest("Find Potion", "Health Potion"));
        questManager.AddQuest(new KillQuest("Defeat 1 Enemies", 1));
    }
}
