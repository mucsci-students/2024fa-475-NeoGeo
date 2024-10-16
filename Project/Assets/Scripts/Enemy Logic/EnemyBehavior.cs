using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject girard;
    private int wait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        girard = GameObject.Find("Girard");
        if(Math.Abs(this.transform.position.x - girard.transform.position.x) < 0.5
        && Math.Abs(this.transform.position.y - girard.transform.position.y) < 0.5 && wait < 0)
        {
            this.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Attack");
            wait = 90;
        }
        wait--;
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
                    playerHealth.TakeDamage(5); // Call the TakeDamage method
                }

            }
        
        else if (col.gameObject.CompareTag("Weapon"))
        {

                // Get the script component that has the TakeDamage method
                var enemyHealth = GetComponentInParent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(10); // Call the TakeDamage method
                }

            }
        }
    }

