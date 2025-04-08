using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TagEnemyAI : MonoBehaviour
{
    public float detectionRange = 12f;
    public float stoppingDistance = 2f;

    public Transform targetRunner;
    public NavMeshAgent agent;
    public TagEnemyAnimator animator;
    public TagPlayerRole role;
    private ITagHandler tagHandler;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<TagEnemyAnimator>();
        //role = GetComponent<TagPlayerRole>();
        tagHandler = GetComponent<ITagHandler>();
    }
    public void Start()
    {
        role = FindFirstObjectByType<TagPlayerRole>();
    }
    private void Update()
    {
        if (role.CurrentRole != TagPlayerRole.Role.Taya) return;

        FindTargetRunner();

        if (targetRunner == null) return;

        float distance = Vector3.Distance(transform.position, targetRunner.position);

        if (distance > detectionRange)
        {
            StopChasing();
            return;
        }

        if (distance > stoppingDistance)
        {
            agent.SetDestination(targetRunner.position);
            animator?.PlayMove();
        }
        else
        {
            agent.ResetPath();
            animator?.PlayIdle();
            tagHandler?.AttemptTag(); 
        }
    }

    private void FindTargetRunner()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        float closestDist = Mathf.Infinity;
        Transform closest = null;

        foreach (var obj in players)
        {
            TagPlayerRole r = obj.GetComponent<TagPlayerRole>();
            if (r != null && r.CurrentRole == TagPlayerRole.Role.Runner)
            {
                float dist = Vector3.Distance(transform.position, obj.transform.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = obj.transform;
                }
            }
        }

        targetRunner = closest;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
    private void StopChasing()
    {
        agent.ResetPath();
        animator?.PlayIdle();
    }
}
