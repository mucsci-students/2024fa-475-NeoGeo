using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeoBow : Weapon
{
    int arrows = 10;
    private float chargeTime;

    // Start is called before the first frame update
    void Start()
    {
        wpnSprite = "bow.png";
        damage = 7;
        weight = .5;
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            chargeTime = 0f; // Reset bow charge time
        }

        if (Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime; // Increment charge time
        }

        // Fire the bow when the button is released
        if (Input.GetMouseButtonUp(0))
        {
            FireArrow(chargeTime);
        }
    }

    void FireArrow(float charge)
    {
        //todo
    }
    }

    

    void Slash() //speed of movement based on the weight?
    {
        wpnAnimator.SetTrigger("Slash"); // Assuming you have a trigger in the Animator

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
