using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    [SerializeField]
    private int health;            // Current health
    [SerializeField]
    private int maxHealth;        // Current maximum health (per heart)
    [SerializeField]
    private int maxTotalHealth;   // Total health (full hearts)

    public int Health => health;
    public int MaxHealth => maxHealth;
    public int MaxTotalHealth => maxTotalHealth;

    private HealthBarController healthBarController; // Reference to health bar controller

    private void Awake()
    {
        // Find HealthBarController in the scene
        healthBarController = FindObjectOfType<HealthBarController>();
    }

    public void Heal(int amount)
    {
        health += amount; // Add health
        ClampHealth(); // Ensure health does not exceed max
        onHealthChangedCallback?.Invoke(); // Trigger health change callback
        healthBarController.UpdateHeartsHUD(); // Update UI
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Subtract health
        ClampHealth(); // Ensure health does not drop below zero
        onHealthChangedCallback?.Invoke(); // Trigger health change callback
        healthBarController.UpdateHeartsHUD(); // Update UI
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1; // Increase max health by one heart
            health = maxHealth; // Set current health to new max health
            onHealthChangedCallback?.Invoke(); // Trigger health change callback
            healthBarController.UpdateHeartsHUD(); // Update UI
        }
    }

    private void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth); // Clamp health within bounds
    }
}
