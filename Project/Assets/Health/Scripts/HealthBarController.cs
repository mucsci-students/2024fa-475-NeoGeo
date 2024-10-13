using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Sprite emptyHeartSprite;
    public Sprite halfHeartSprite;
    public Sprite fullHeartSprite;

    private PlayerHealth HP;

    public Image[] heartImages;  // UI Images representing the hearts
    private int fullHeartCount;   // Count of full hearts

    private void Start()
    {
        fullHeartCount = heartImages.Length;  // Start with maximum full hearts
        UpdateHeartsHUD();
    }

    public void UpdateHeartsHUD()
{
    for (int i = 0; i < heartImages.Length; i++)
    {
        if (i < fullHeartCount)
        {
            heartImages[i].sprite = fullHeartSprite;
        }
        else if (i == fullHeartCount && HP.Health % 5 != 0) // Check for half heart
        {
            heartImages[i].sprite = halfHeartSprite;
        }
        else
        {
            heartImages[i].sprite = emptyHeartSprite;
        }
    }
}

    public void TakeDamage(int damage)
    {
        int heartsToRemove = damage / 5;  // Each heart worth 5 HP
        fullHeartCount -= heartsToRemove;  // Subtract full hearts

        // Make sure we don't go below zero
        if (fullHeartCount < 0)
        {
            fullHeartCount = 0;
        }

        UpdateHeartsHUD();  // Refresh the UI
    }

    public void Heal(int healing)
    {
        int heartsToAdd = healing / 5;  // Each heart worth 5 HP
        fullHeartCount += heartsToAdd;  // Add full hearts

        // Make sure we don't exceed the maximum hearts
        if (fullHeartCount > heartImages.Length)
        {
            fullHeartCount = heartImages.Length;
        }

        UpdateHeartsHUD();  // Refresh the UI
    }
}
