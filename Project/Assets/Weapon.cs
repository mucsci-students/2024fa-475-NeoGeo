using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generic Weapon template, create prefabs with different sprite and attributes
public class Weapon : MonoBehaviour
{
    // Public for testing
    public Rigidbody2D wpnBody;
    public CompositeCollider2D wpnCollider;
    public Sprite wpnSprite;
    public int damage = 1;
    public float weight = 1.0f;
    public bool isProjectile = false;

    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        wpnBody = GetComponent<Rigidbody2D>();
        wpnBody.gravityScale = 0;
        wpnCollider = GetComponent<CompositeCollider2D>();
        render = GetComponent<SpriteRenderer>();

        if (render != null)
        {
            // Set the sprite to the SpriteRenderer's sprite if not already assigned
            if (wpnSprite == null)
            {
                wpnSprite = render.sprite;
            }

            // Assign the sprite to the SpriteRenderer
            render.sprite = wpnSprite;
        }
        else
        {
            Debug.LogError("Weapon doesnt have a sprite added.");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Try to get the Health component of the object hit
        PlayerHealth targetHealth = col.gameObject.GetComponent<PlayerHealth>();
        
        // If the object has a Health component, deal damage
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
    }
}
