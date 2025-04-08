using UnityEngine;

public class TagEnemyAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayMove()
    {
        animator?.SetBool("isMoving", true);
    }

    public void PlayIdle()
    {
        animator?.SetBool("isMoving", false);
    }
}
