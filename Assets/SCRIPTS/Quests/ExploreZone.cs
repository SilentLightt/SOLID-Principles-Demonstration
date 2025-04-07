using UnityEngine;

public class ExploreZone : MonoBehaviour
{
    [SerializeField] private string locationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var questManager = FindFirstObjectByType<QuestManager>();
            questManager?.ReportExplore(locationName);
        }
    }
}
