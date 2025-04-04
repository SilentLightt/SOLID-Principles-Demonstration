//using UnityEngine;

//public class EnemyAnimation : MonoBehaviour
//{
//    private Animator animator;

//    private void Start()
//    {
//        animator = GetComponent<Animator>();
//    }

//    public void PlayMoveAnimation()
//    {
//        animator.SetBool("isMoving", true);
//    }

//    public void PlayAttackAnimation()
//    {
//        animator.SetBool("Attacking", true);
//    }
//    public void StopAttackAnimation()
//    {
//        //animator.ResetTrigger("Attacking"); // Stops attack animation
//        animator.SetBool("Attacking", false);
//    }

//    public void PlayDeathAnimation()
//    {
//        animator.SetTrigger("Die");
//    }
//    public void PlayIdleAnimation()
//    {
//        animator.SetBool("isMoving", false);
//    }
//}
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private EnemyAttack enemyAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        enemyAttack = GetComponentInParent<EnemyAttack>(); // Reference to EnemyAttack
    }

    public void PlayMoveAnimation() => animator.SetBool("isMoving", true);
    public void PlayAttackAnimation() => animator.SetTrigger("Attack");
    public void PlayIdleAnimation() => animator.SetBool("isMoving", false);
    public void PlayDeathAnimation() => animator.SetTrigger("Die");

    // These methods will be called by animation events
    public void AnimationEvent_ApplyDamage() => enemyAttack.ApplyDamage();
    public void AnimationEvent_EndAttack() => enemyAttack.EndAttack();
}
