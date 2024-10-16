using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    public int health;               // Current health
    public int maxHealth = 100;      // Current maximum health
    public int maxTotalHealth = 100; // Total health (full hearts, set to 6)

    private HealthBarController healthBarController; // Reference to health bar controller
    private Rigidbody2D rb; // Reference to Rigidbody2D component for applying force

    public float knockbackForce = 2f; // The force applied when taking damage
    public float rotationAmount = 10f; // How much to rotate when hit

    private void Start()
    {
        healthBarController = FindObjectOfType<HealthBarController>(); // Find the health bar controller in the scene
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player

        if (healthBarController == null)
        {
            Debug.LogError("HealthBarController not found in the scene.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the player.");
        }

        health = maxHealth; // Set current health to max health

        // Trigger health change callback to initialize UI only if it's not null
        if (onHealthChangedCallback != null)
        {
            onHealthChangedCallback.Invoke();
        }

        healthBarController.UpdateHeartsHUD(); // Update the hearts on the health bar
    }

    public void Heal(int amount)
    {
        health += amount; // Add health
        ClampHealth(); // Ensure health does not exceed max

        // Trigger health change callback and update UI
        onHealthChangedCallback?.Invoke(); 
        healthBarController.UpdateHeartsHUD(); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Subtract health
        ClampHealth(); // Ensure health does not drop below zero

        // Trigger health change callback and update UI
        onHealthChangedCallback?.Invoke(); 
        healthBarController.UpdateHeartsHUD(); 

        ApplyDamageEffects(); // Apply visual and physical effects when damaged
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 10; // Increase max health by one heart
            health = maxHealth; // Set current health to new max health

            // Trigger health change callback and update UI
            onHealthChangedCallback?.Invoke(); 
            healthBarController.UpdateHeartsHUD(); 
        }
    }

    private void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth); // Clamp health within bounds
    }

    private void ApplyDamageEffects()
    {
        if (rb != null)
        {
            // Apply a small random force to the player for knockback effect
            Vector2 randomForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * knockbackForce;
            rb.AddForce(randomForce, ForceMode2D.Impulse);

            // Apply a small random rotation to create a twitch effect
            float randomRotation = Random.Range(-rotationAmount, rotationAmount);
            rb.MoveRotation(rb.rotation + randomRotation);
        }
    }
}
