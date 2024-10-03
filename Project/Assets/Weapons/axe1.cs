using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NeoAxe : Weapon
{

    // Start is called before the first frame update
    void Start()
    {
        damage = 23;
        weight = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Slash();
        }
    }

    

    void Slash() //speed of movement based on the weight?
    {
        wpnAnimator.SetTrigger("Slash"); // Assuming you have a trigger in the Animator

        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, 1f); // radius can change if needed

        
    }
}
