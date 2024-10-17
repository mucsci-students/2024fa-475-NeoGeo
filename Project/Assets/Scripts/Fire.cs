using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] frames;
    public float framesPerSecond = 12f; 

    private CapsuleCollider2D burnArea;
    private int currentFrame;
    private int damage = 5;

    private float timer = 0.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        burnArea = GetComponent<CapsuleCollider2D>();
        currentFrame = 0;
    }

    void Update()
    {
        
        if (frames.Length > 0)
        {
            currentFrame = (int)((Time.time * framesPerSecond) % frames.Length);
            spriteRenderer.sprite = frames[currentFrame];
        }
        else
        {
            Debug.LogWarning("Frames array is empty. No sprite to display.");
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is burning");

            timer += Time.deltaTime;
            if (timer >= 1.0f) 
            {
                
                var playerHealth = col.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage); 
                }

                timer = 0f; 
            }
        }
    }
}
