using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is the parent weapon class of all weapons, each subclass inherits these attributes
public class Weapon : MonoBehaviour
{
    
    private Rigidbody2D wpnBody = new Rigidbody2D();
    private Animator wpnAnimator = new Animator();
    private Sprite wpnSprite;
    public int damage;
    private int weight;
    private bool isProjectile = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        wpnSprite = GetComponent<Sprite>();
        wpnAnimator = GetComponent<Animator>();
        
    }

    void update()
    {

    }
}