using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    private int health;            // Current health
    private int maxHealth = 6;    // Current maximum health (set to 6 by default)
    private int maxTotalHealth = 6; // Total health (full hearts, set to 6)

    public int Health => health;
    public int MaxHealth => maxHealth;
    public int MaxTotalHealth => maxTotalHealth;

    private HealthBarController healthBarController; // Reference to health bar controller

    private void Start()
    {
        healthBarController = FindObjectOfType<HealthBarController>(); // Find the health bar controller in the scene
        health = maxHealth; // Set current health to max health
        onHealthChangedCallback?.Invoke(); // Trigger health change callback to initialize UI
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
