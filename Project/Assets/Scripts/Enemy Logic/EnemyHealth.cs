using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    // Start is called before the first frame update    private Rigidbody2D rb; // Reference to Rigidbody2D component for applying force

    public float knockbackForce = 2f; // The force applied when taking damage
    public float rotationAmount = 10f; // How much to rotate when hit
    public Rigidbody2D rb;
    public CircleCollider2D col;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the player
        col =  GetComponent<CircleCollider2D>();
        health = maxHealth; // Set current health to max health
        
    }

    void Update()
    {
        if (health <= 0)
        {
            rb.bodyType= RigidbodyType2D.Dynamic;
            Debug.Log("enemy has died");
        }
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


