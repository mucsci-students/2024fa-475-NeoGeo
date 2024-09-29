using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody2D swordbody = new Rigidbody2D();
    private Animator swordanimator = new Animator();
    private Sprite swordsprite;
    public int damage;
    private int weight;


    // Start is called before the first frame update
    void Start()
    {
        
        swordsprite = GetComponent<Sprite>();
        swordanimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Slash();
        }
    }

    

    void Slash()
    {
        swordAnimator.SetTrigger("Slash"); // Assuming you have a trigger in the Animator

        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, 1f); // radius can change if needed

        foreach (Collider2D target in hitTargets)
        {
            target.hp = target.GetComponent<hp>();
            if (target.hp != null)
            {
                target.hp.TakeDamage(damage); // slash damage can be set
            }
        }
    }
}
