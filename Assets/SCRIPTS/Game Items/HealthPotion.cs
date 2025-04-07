using UnityEngine;

public class HealthPotion : GameItem
{
    public int HealAmount { get; private set; }
    public ParticleSystem healEffect;
    public GameObject healeffectob;
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
            playerHealth.UpdateUI(); 

            if (healEffect != null)
            {
                healEffect.transform.SetParent(null);
                healeffectob.SetActive(true);
                healEffect.Play();
                Destroy(healEffect.gameObject, healEffect.main.duration);
            }

            PlayerInventory inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.RemoveItem(this);
            }

            Destroy(gameObject, 1.5f);
        }
    }

}
