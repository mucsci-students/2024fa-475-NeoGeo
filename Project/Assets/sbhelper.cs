using System.Collections;
using System.Collections.Generic;
using System.Data;
using Pathfinding;
using UnityEngine;

public class sbhelper : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemyAggroRange range;
    private EnemyHealth health;
    private Animator sb;
    public EffectAnimation xpl;

    private BoxCollider2D box;
    void Start()
    {
        range = GetComponentInParent<EnemyAggroRange>();
        health = GetComponentInParent<EnemyHealth>();
        sb = GetComponentInParent<Animator>();
        sb.SetBool("isMoving", true);
        xpl = GetComponent<EffectAnimation>();
        xpl.isenabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (range.GetComponent<AIPath>().enabled == true)
        {
            sb.SetBool("charge", true);

        }
        if(health.health <=20 && range.GetComponent<AIPath>().enabled == true)
        {
            sb.SetBool("isArmed", true);
            if (Time.deltaTime == Time.deltaTime + 1)
                xpl.isenabled = true;

            
        }
        
        
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the collided object's tag is "Player"
        if (col.gameObject.CompareTag("Player"))
        {

                // Get the script component that has the TakeDamage method
                var playerHealth = col.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10); // Call the TakeDamage method
                }

            }
        }
    }

