using UnityEngine;

public class HealthPotion : GameItem
{
    public int HealAmount { get; private set; }
    public ParticleSystem healEffect; // Assign in the Inspector

    public HealthPotion() : base("Health Potion")
    {
        HealAmount = 50;
    }

    public override void Use()
    {
        PlayerHealth playerHealth = GameObject.FindFirstObjectByType<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.RestoreHealth(HealAmount);
            Debug.Log($"{ItemName} used! Restored {HealAmount} HP.");

            if (healEffect != null)
            {
                healEffect.transform.SetParent(null);
                healEffect.Play();
                Destroy(healEffect.gameObject, healEffect.main.duration);
            }

            // Remove from inventory before destroying
            PlayerInventory inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.RemoveItem(this);
            }

            Destroy(gameObject, 1.5f);
        }
    }

}
