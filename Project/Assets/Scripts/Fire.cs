using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] frames;
    public float framesPerSecond = 12f; // Frames per second

    private CapsuleCollider2D burnArea;

    private int currentFrame;

    private int damage = 5;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        burnArea = GetComponent<CapsuleCollider2D>();
        currentFrame = 0;
    }

    void Update()
    {
        currentFrame = (int)((Time.time * framesPerSecond) % frames.Length);

        spriteRenderer.sprite = frames[currentFrame];
    }

    private float timer = 0.0f;

    void OnCollisionStay2D(Collision2D col)
    {
        // Check if the collided object's tag is "Player"
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is burning");

            timer += Time.deltaTime;
            if (timer >= 1.0f) // Check if 1 second has passed
            {
                // Get the script component that has the TakeDamage method
                var playerHealth = col.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage); // Call the TakeDamage method
                }

                timer = 0f; // Reset the timer after applying damage
            }
        }
    }


}
