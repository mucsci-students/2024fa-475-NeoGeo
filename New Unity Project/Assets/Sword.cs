using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody2D swordbody = new Rigidbody2D();
    private Animator swordanimator = new Animator();
    private Sprite swordsprite;
    public int damage;
    //private int weight; -- possibly affect players move speed/ jump height?


    // Start is called before the first frame update
    void Start()
    {
        
        swordsprite = GetComponent<Sprite>();
        //swordanimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //switching direction with character
    void FlipX()
    {
        transform.rotation.y *= -1;
    }

    void Slash()
    {
        //animate slash
        //-damage to target if hit
    }
}
