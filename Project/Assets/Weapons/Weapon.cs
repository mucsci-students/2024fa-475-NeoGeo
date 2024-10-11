using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Generic Weapon template, create prefabs with different sprite and attributes
public class Weapon : MonoBehaviour
{
    //public for testing
    public Rigidbody2D wpnBody;
    public CompositeCollider2D wpnCollider;
    public SpriteRenderer wpnSprite;
    public int damage = 1;
    public int weight = 1;
    public bool isProjectile = false;
    

    // Start is called before the first frame update
    void Start()
    {
        wpnBody = new Rigidbody2D();
        wpnCollider = new CompositeCollider2D();
        wpnSprite = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Try to get the Health component of the object hit
        Health targetHealth = col.gameObject.GetComponent<Health>();
        
        // If the object has a Health component and is alive, deal damage
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);  // Subtract 10 hp
        }
    }

}