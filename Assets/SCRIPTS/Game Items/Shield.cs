using UnityEngine;
using System.Collections;

public class Shield : GameItem
{
    public int Defense { get; private set; }
    public ParticleSystem shieldEffect;
    public GameObject shield;
    public float shieldDuration = 5f;

    public Shield() : base("Shield")
    {
        Defense = 15;
    }

    public override void Use()
    {
        PlayerHealth playerHealth = GameObject.FindFirstObjectByType<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.ActivateShield(Defense, shieldDuration);
            Debug.Log($"{ItemName} is used! Reduces damage by {Defense} for {shieldDuration} seconds.");

            if (shieldEffect != null)
            {
                shieldEffect.Play();
                //Destroy(shieldEffect.gameObject, shieldEffect.main.duration); // Destroy effect after it finishes
            }

            //Destroy(gameObject, 1.5f);
        }
    }
}
