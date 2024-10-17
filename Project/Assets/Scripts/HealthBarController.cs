using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Sprite emptyHeartSprite; // Sprite for an empty heart
    public Sprite halfHeartSprite;  // Sprite for a half heart
    public Sprite fullHeartSprite;  // Sprite for a full heart
    public Animator healthbar;

    public GameObject player;        // Reference to the Player GameObject
    public PlayerHealth hp;          // Reference to the PlayerHealth component
    public Image[] heartImages;      // Array to hold the heart images

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        hp = player.GetComponent<PlayerHealth>();

        if (hp == null)
        {
            Debug.LogError("PlayerHealth component not found.");
            return;
        }

        // Initialize the heartImages array with 5 heart images
        heartImages = new Image[5];
        
        // Assuming heart images are direct children of the Panel object
        Transform panel = transform.Find("Panel");
        if (panel == null)
        {
            Debug.LogError("Panel object not found.");
            return;
        }

        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i] = panel.GetChild(i).GetComponent<Image>();
        }

        UpdateHeartsHUD();
    }

    // Updates the hearts on the HUD based on the current health
    public void UpdateHeartsHUD()
    {
        if (hp == null) return;
        healthbar.SetInteger("hp", hp.health);

    }
        
}
