using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;
    private QuestManager questManager;

    [SerializeField] private Image healthBar; 
    [SerializeField] private Canvas healthBarCanvas; 

    private Camera mainCamera;
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        questManager = FindFirstObjectByType<QuestManager>();
        mainCamera = Camera.main;

        if (mainCamera != null && healthBarCanvas != null && healthBarCanvas.renderMode == RenderMode.WorldSpace)
        {
            healthBarCanvas.worldCamera = mainCamera;
        }
        else
        {
            Debug.LogWarning("Main Camera not found or health bar canvas is not set to World Space.");
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthUI();
    }

    private void Die()
    {
        questManager?.ReportKill(); 
        Destroy(gameObject);
    }

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
           // Debug.Log("Health bar fill amount: " + healthBar.fillAmount); // Log to check if it's updating
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
