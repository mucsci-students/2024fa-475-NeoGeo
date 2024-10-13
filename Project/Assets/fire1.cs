using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire1 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 
    public Sprite[] frames; 
    public float framesPerSecond = 12f; // Frames per second

    private CapsuleCollider2D burn;
    private int currentFrame; 

    
    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentFrame = 0;
        burn = GetComponent<CapsuleCollider2D>();
    }

    
    void Update()
    {
        // Calculate the current frame index based on time
        currentFrame = (int)(Time.time * framesPerSecond) % frames.Length;

        // Update the sprite to the current frame
        spriteRenderer.sprite = frames[currentFrame];
    }

    public int damagePerSecond = 5; // Damage dealt per second
    private float damageInterval = 1f; // Time interval between damage applications (1 second)
    private float nextDamageTime = 0f; // Tracks when to deal the next damage

    void OnCollisionStay(Collision collision)
    {
        // Check if it's time to deal damage
        if (Time.time >= nextDamageTime)
        {
            // Assuming the collided object has a health component
// Get the PlayerHealth component from the collided object
var health = collision.gameObject.GetComponent<PlayerHealth>();

// Check if the PlayerHealth component is not null
if (health != null)
{
    // Call a method on the PlayerHealth script to apply damage
    health.TakeDamage(damagePerSecond);
}
            if (health != null)
            {
                health.TakeDamage(damagePerSecond);
            }

            // Update the next damage time
            nextDamageTime = Time.time + damageInterval;
        }
    }
}

