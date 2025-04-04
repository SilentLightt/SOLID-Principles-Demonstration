using UnityEngine;

public class Weapon : GameItem
{
    public int Damage { get; private set; }
    public Animator anim; 
    private bool isAttacking = false; 
    public GameObject floatingTextPrefab; 

    public Weapon() : base("Axe")
    {
        Damage = 5;
    }

    public override void Use()
    {
        if (anim == null)
        {
            Debug.LogError("Animator not found on weapon!");
            return;
        }

        anim.SetTrigger("Attack");
        isAttacking = true; 
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!isAttacking) return; // Only apply damage if the attack is active

        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
            GameObject damageText = Instantiate(floatingTextPrefab, enemy.transform.position + Vector3.up * 1f, Quaternion.identity);
            damageText.GetComponent<FloatingText>().SetText(Damage.ToString());
            Debug.Log($"Hit {other.gameObject.name}, dealing {Damage} damage!");
        }
    }

    public void EndAttack()
    {
        isAttacking = false; 
    }
    public override void Equip(Transform parent)
    {
        base.Equip(parent);
        anim = GetComponent<Animator>(); 
    }
}
