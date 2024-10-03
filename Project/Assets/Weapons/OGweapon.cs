using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the parent weapon class of all weapons, each subclass inherits these attributes
public class Weapon : MonoBehaviour
{
    //public for testing
    public Rigidbody2D wpnBody = new Rigidbody2D();
    public Animator wpnAnimator = new Animator();
    public SpriteRenderer wpnSprite;
    public int damage;
    public int weight;
    public bool isProjectile = false;
    

    // Start is called before the first frame update
    void Start()
    {
        wpnSprite = GetComponent<SpriteRenderer>();
        wpnAnimator = GetComponent<Animator>();
        
    }

    
    void Slash()
    {
        wpnAnimator.SetTrigger("Slash"); // Assuming you have a trigger in the Animator

        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, 1f); // radius can change if needed

        //foreach (Collider2D target in hitTargets)
        //{
        //    target.hp = target.GetComponent<hp>();
        //    if (target.hp != null)
        //    {
        //        target.hp.TakeDamage(damage); // slash damage can be set
        //   }
        //}
    }

}