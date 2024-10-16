using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPCHealth : MonoBehaviour
{

    public int health;            // Current health
    public int maxHealth = 5;    // Current maximum health (set to 6 by default)
    public int maxTotalHealth = 5; // Total health (full hearts, set to 6)

    private Rigidbody2D rb; // Reference to Rigidbody2D component for applying force

    public float knockbackForce = 2f; // The force applied when taking damage
    public float rotationAmount = 10f; // How much to rotate when hit

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player

        

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the player.");
        }

        health = maxHealth; // Set current health to max health
        
    }

    public void Heal(int amount)
    {
        health += amount; // Add health
        ClampHealth(); // Ensure health does not exceed max
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage; // Subtract health
        ClampHealth(); // Ensure health does not drop below zero
        

        ApplyDamageEffects(); // Apply visual and physical effects when damaged
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