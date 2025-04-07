using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public string areaName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager questManager =FindFirstObjectByType<QuestManager>();
            if (questManager != null)
            {
                //questManager.AreaEntered(areaName);
            }
        }
    }
}
