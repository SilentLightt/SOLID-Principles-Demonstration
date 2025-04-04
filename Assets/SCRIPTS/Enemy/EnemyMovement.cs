//using UnityEngine;

//public class EnemyMovement : MonoBehaviour
//{
//    public float speed = 3f;
//    public float rotationSpeed = 5f; 
//    private Transform target;

//    private void Start()
//    {
//        target = GameObject.FindGameObjectWithTag("Player").transform;
//    }

//    public void MoveTowardsTarget()
//    {
//        if (target != null)
//        {
//            // Move towards the player
//            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

//            // Rotate towards the player smoothly
//            Vector3 direction = (target.position - transform.position).normalized;
//            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
//        }
//    }
//}
//original code
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float stoppingDistance = 2f; // Stop moving when within attack range
    public float detectionRange = 10f; // AI only moves if player is within this range

    private Transform target;
    private NavMeshAgent agent;
    private EnemyAnimation animationController;
    private bool isAttacking = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animationController = GetComponentInChildren<EnemyAnimation>();

        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;
    }

    private void Update()
    {
        if (target == null || isAttacking) return;

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer > detectionRange)
        {
            StopChasing(); // Stop movement if player is out of detection range
            return;
        }

        if (distanceToPlayer > stoppingDistance)
        {
            agent.SetDestination(target.position);
            animationController?.PlayMoveAnimation();
        }
        else
        {
            agent.ResetPath(); // Stop moving when in attack range
            animationController?.PlayIdleAnimation();
        }
    }

    private void StopChasing()
    {
        agent.ResetPath();
        animationController?.PlayIdleAnimation();
    }

    public void StopMoving()
    {
        isAttacking = true;
        agent.isStopped = true;
        animationController?.PlayIdleAnimation();
    }

    public void ResumeMoving()
    {
        isAttacking = false;
        agent.isStopped = false;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}


