using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generic Weapon template, create prefabs with different sprite and attributes
public class Weapon : MonoBehaviour
{
    //public for testing
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
        wpnCollider = GetComponent<CompositeCollider2D>();
        wpnSprite = GetComponent<Sprite>();
        render = GetComponent<SpriteRenderer>();
        render.sprite = wpnSprite;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Try to get the Health component of the object hit
        PlayerHealth targetHealth = col.gameObject.GetComponent<PlayerHealth>();
        
        // If the object has a Health component and is alive, deal damage
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);  // Subtract 10 hp
        }
    }

}