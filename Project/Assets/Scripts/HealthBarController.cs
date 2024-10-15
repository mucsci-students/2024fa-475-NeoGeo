using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Sprite emptyHeartSprite;
    public Sprite halfHeartSprite;
    public Sprite fullHeartSprite;

    private PlayerHealth hp; // Reference to the PlayerHealth component

    public Image[] heartImages; // UI Images representing the hearts

    private void Start()
    {
        // Get the PlayerHealth component from the parent GameObject
        hp = GetComponentInParent<PlayerHealth>(); // Use GetComponentInParent to find PlayerHealth on the player

        if (hp == null)
        {
            Debug.LogError("PlayerHealth component not found in parent.");
            return;
        }

        // Subscribe to health changes
        hp.onHealthChangedCallback += UpdateHeartsHUD;

        // Update hearts at the start to reflect initial health
        UpdateHeartsHUD();
    }

    private void OnDestroy()
    {
        // Unsubscribe from health changes to avoid memory leaks
        if (hp != null)
        {
            hp.onHealthChangedCallback -= UpdateHeartsHUD;
        }
    }

    // Updates the hearts on the HUD based on the current health
    public void UpdateHeartsHUD()
    {
        if (hp == null) return;

        float currentHealth = hp.Health;
        float maxHealth = hp.MaxHealth;
        int heartCapacity = 5; // Assuming each heart represents 5 HP

        for (int i = 0; i < heartImages.Length; i++)
        {
            int heartPosition = (i + 1) * heartCapacity;

            if (currentHealth >= heartPosition)
            {
                // Full heart
                heartImages[i].sprite = fullHeartSprite;
            }
            else if (currentHealth > heartPosition - heartCapacity)
            {
                // Half heart
                heartImages[i].sprite = halfHeartSprite;
            }
            else
            {
                // Empty heart
                heartImages[i].sprite = emptyHeartSprite;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        // HP should handle the damage; UpdateHeartsHUD will be called automatically
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }

    public void Heal(int healing)
    {
        // HP should handle the healing; UpdateHeartsHUD will be called automatically
        if (hp != null)
        {
            hp.Heal(healing);
        }
    }
}
