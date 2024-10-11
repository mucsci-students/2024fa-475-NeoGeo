using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 6;       // Max player health (6 hearts)
    public int currentHealth;       // Current health value

    public Sprite[] heartSprites;     // Array of UI Images to display hearts
    public Sprite fullHeart;        // Sprite for full heart
    public Sprite halfHeart;        // Sprite for half heart
    public Sprite emptyHeart;       // Sprite for empty heart

    void Start()
    {
        currentHealth = maxHealth;  // Start with full health
        UpdateHealthUI();
    }

    // This method updates the heart UI based on current health
    void UpdateHealthUI()
    {
        for (int i = 0; i < heartSprites.Length; i++)
        {
            if (i < currentHealth / 2)
            {
                heartSprites[i] = fullHeart;
            }
            else if (i == currentHealth / 2 && currentHealth % 2 == 1)
            {
                heartSprites[i] = halfHeart;
            }
            else
            {
                heartSprites[i] = emptyHeart;
            }
        }
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();
    }

    // Method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthUI();
    }
}
