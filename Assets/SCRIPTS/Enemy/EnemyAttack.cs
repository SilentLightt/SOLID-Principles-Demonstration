using TMPro;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    public GameObject damageTextPrefab; // Assign in Inspector

    public Transform target;
    private float lastAttackTime;
    private EnemyAnimation animationController;
    private EnemyMovement movementController;
    private bool isAttacking = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animationController = GetComponentInChildren<EnemyAnimation>();
        movementController = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (target == null || isAttacking) return;

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            StartAttack();
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        lastAttackTime = Time.time;
        movementController.StopMoving();
        animationController.PlayAttackAnimation(); // Animation event will trigger ApplyDamage
    }

    public void ApplyDamage() // Called by Animation Event
    {
        if (target == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer > attackRange)
        {
            EndAttack();
            return;
        }

        target.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
        SpawnDamageText(attackDamage); // Spawn text when damage is applied
    }

    private void SpawnDamageText(int damage)
    {
        if (damageTextPrefab != null && target != null)
        {
            // Generate a small random offset near the target
            Vector3 spawnPosition = target.position;

            // Create an empty parent object to hold the text
            GameObject textHolder = new GameObject("DamageTextHolder");
            textHolder.transform.position = spawnPosition;

            // Instantiate the text and parent it to the holder
            GameObject textInstance = Instantiate(damageTextPrefab, spawnPosition, Quaternion.identity);
            textInstance.transform.SetParent(textHolder.transform, true); // Maintain world position

            // Set the damage text
            textInstance.GetComponent<TextMeshPro>().text = damage.ToString();

            // Destroy both after animation ends
            Destroy(textHolder, 1.5f);
        }
    }


    public void EndAttack() // Called at the end of the animation
    {
        isAttacking = false;
        movementController.ResumeMoving();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

//using UnityEngine;
//using UnityEngine.AI;

//public class EnemyAttack : MonoBehaviour
//{
//    public float attackRange = 2f;
//    public int attackDamage = 10;
//    public float attackCooldown = 1.5f;
//    public float attackDelay = 0.5f; // Delay before damage applies
//    public float resumeMoveDelay = 1f; // Time before enemy moves again
//    private Transform target;
//    private float lastAttackTime;
//    private EnemyAnimation animationController;
//    private EnemyMovement movementController;
//    private bool isAttacking = false;

//    private void Start()
//    {
//        target = GameObject.FindGameObjectWithTag("Player").transform;
//        animationController = GetComponentInChildren<EnemyAnimation>();
//        movementController = GetComponent<EnemyMovement>();
//    }

//    private void Update()
//    {
//        if (target == null || isAttacking) return;

//        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

//        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
//        {
//            Attack();
//        }
//    }

//    private void Attack()
//    {
//        isAttacking = true;
//        lastAttackTime = Time.time;
//        movementController.StopMoving(); // Stop movement when attacking
//        animationController?.PlayAttackAnimation();
//        //Invoke(nameof(ApplyDamage), attackDelay);
//    }

//    private void ApplyDamage()
//    {
//        if (target == null || !isAttacking) return;

//        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
//        if (distanceToPlayer > attackRange)
//        {
//            CancelAttack();
//            return;
//        }

//        target.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
//        Invoke(nameof(ResumeMovement), resumeMoveDelay); // Wait before moving again
//    }

//    private void CancelAttack()
//    {
//        isAttacking = false;
//        animationController.StopAttackAnimation();
//        movementController.ResumeMoving();
//    }
//    public void ApplyDamageEvent()
//    {
//        ApplyDamage();
//    }

//    private void ResumeMovement()
//    {
//        isAttacking = false;
//        movementController.ResumeMoving();
//    }
//    public void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, attackRange);
//    }
//}
//using UnityEngine;

//public class EnemyAttack : MonoBehaviour
//{
//    public float attackRange = 2f;
//    public int attackDamage = 10;
//    public float attackCooldown = 1.5f;

//    private Transform target;
//    private float lastAttackTime;
//    private EnemyAnimation animationController;
//    private EnemyMovement movementController;
//    private bool isAttacking = false;

//    private void Start()
//    {
//        target = GameObject.FindGameObjectWithTag("Player").transform;
//        animationController = GetComponentInChildren<EnemyAnimation>();
//        movementController = GetComponent<EnemyMovement>();
//    }

//    private void Update()
//    {
//        if (target == null || isAttacking) return;

//        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

//        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
//        {
//            StartAttack();
//        }
//    }

//    private void StartAttack()
//    {
//        isAttacking = true;
//        lastAttackTime = Time.time;
//        movementController.StopMoving();
//        animationController.PlayAttackAnimation(); // Animation event will trigger ApplyDamage
//    }

//    public void ApplyDamage() // Called by Animation Event
//    {
//        if (target == null) return;

//        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
//        if (distanceToPlayer > attackRange)
//        {
//            EndAttack();
//            return;
//        }

//        target.GetComponent<PlayerHealth>()?.TakeDamage(attackDamage);
//    }

//    public void EndAttack() // Called at the end of the animation
//    {
//        isAttacking = false;
//        movementController.ResumeMoving();
//    }
//    public void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, attackRange);
//    }
//}
