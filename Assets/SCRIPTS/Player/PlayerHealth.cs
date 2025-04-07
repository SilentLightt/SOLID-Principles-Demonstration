using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int pmaxHealth = 50;
    private int pcurrentHealth;
    private int currentDefense = 0;
    private bool isDead = false;

    [SerializeField] private TextMeshProUGUI healthText;  // Assign in Inspector
    [SerializeField] private TextMeshProUGUI defenseText; // Assign in Inspector

    private void Start()
    {
        pcurrentHealth = pmaxHealth;
        UpdateUI(); // Update UI at the start
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        int finalDamage = Mathf.Max(damage - currentDefense, 0);
        pcurrentHealth -= finalDamage;

        if (pcurrentHealth <= 0)
        {
            Die();
        }

        UpdateUI(); // Refresh UI after taking damage
    }

    public void ActivateShield(int defense, float duration)
    {
        currentDefense = defense;
        UpdateUI();
        StartCoroutine(RemoveShieldAfterTime(duration));
    }
    public void RestoreHealth(int amount)
    {
        if (isDead) return; // Prevent healing if dead

        pcurrentHealth = Mathf.Min(pcurrentHealth + amount, pmaxHealth);
        Debug.Log($"Player healed {amount} HP. Current health: {pcurrentHealth}");
    }
    private IEnumerator RemoveShieldAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        currentDefense = 0;
        UpdateUI();
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        if (healthText != null)
            healthText.text = $"Health: {pcurrentHealth}/{pmaxHealth}";

        if (defenseText != null)
            defenseText.text = $"Defense: {currentDefense}";
    }
}

//using UnityEngine;
//using System.Collections;
//public class PlayerHealth : MonoBehaviour
//{
//    public int pmaxHealth = 50;
//    private int pcurrentHealth;
//    private bool isDead = false;
//    private int currentDefense = 0; // Added defense variable

//    private void Start()
//    {
//        pcurrentHealth = pmaxHealth;
//    }

//    public void TakeDamage(int damage)
//    {
//        if (isDead) return; // Prevent multiple calls

//        pcurrentHealth -= damage;
//        Debug.Log($"Player took {damage} damage. Current health: {pcurrentHealth}");

//        if (pcurrentHealth <= 0)
//        {
//            Die();
//        }
//    }
//    public void RestoreHealth(int amount)
//    {
//        if (isDead) return; // Prevent healing if dead

//        pcurrentHealth = Mathf.Min(pcurrentHealth + amount, pmaxHealth);
//        Debug.Log($"Player healed {amount} HP. Current health: {pcurrentHealth}");
//    }
//    public void ActivateShield(int defense, float duration)
//    {
//        currentDefense = defense;
//        Debug.Log($"Shield activated! Damage reduced by {defense} for {duration} seconds.");
//        StartCoroutine(RemoveShieldAfterTime(duration));
//    }

//    private IEnumerator RemoveShieldAfterTime(float duration)
//    {
//        yield return new WaitForSeconds(duration);
//        currentDefense = 0;
//        Debug.Log("Shield expired. Defense returned to normal.");
//    }
//    private void Die()
//    {
//        if (isDead) return; // Prevent redundant calls

//        isDead = true;
//        Debug.Log("Player has died!");
//        gameObject.SetActive(false); // Temporarily disable instead of destroying
//        // Optionally, add a respawn mechanic or game-over screen here.
//    }
//}
