using UnityEngine;
using UnityEngine.AI;

public class TagAIController : MonoBehaviour, ITaggable
{
    [SerializeField] private TagRoleManager roleManager;
    private NavMeshAgent agent;

    public bool IsTagger => roleManager.currentTagger == this;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (IsTagger && roleManager.currentRunner != null)
        {
            agent.SetDestination(((MonoBehaviour)roleManager.currentRunner).transform.position);
        }
    }

    public void OnTagged()
    {
        if (!IsTagger)
        {
            Debug.Log("AI was tagged!");
            roleManager.SwitchRoles();
        }
    }
}
