using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Sprite playerSprite;
    public float speed = 5.0f;
    public Weapon currentWpn;
    private Rigidbody2D body;
    private Animator motion;
    private bool isAlive;
    public string playerName = "Girard";
    public int hp = 100;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        motion = GetComponent<Animator>();
        isAlive = true; // Set isAlive to true initially
    }

    void Update()
    {
        HandleMovement();

        if (hp <= 0)
            Die();
        else if (Input.GetMouseButtonDown(0)) // Left mouse button to attack
        {
            Slash();
        }
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // left/right movement (A/D)
        float verticalInput = Input.GetAxis("Vertical"); // up/down movement (W/S)

        Vector2 velocity = new Vector2(horizontalInput * speed, verticalInput * speed);
        body.velocity = velocity;

        // Set animation parameters
        if (velocity != Vector2.zero && motion != null)
        {
            motion.SetBool("isRunning", true);
            // Optional: Set direction to flip the sprite or add directional animations
            if (horizontalInput != 0)
            {
                transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1); // Flip sprite based on direction
            }
        }
        else if (motion != null)
        {
            motion.SetBool("isRunning", false);
        }
    }

    void Slash()
    {
        if(currentWpn != null)
        {
            if (motion != null)
            {
                motion.SetTrigger("Slash"); // Assuming you have a trigger in the Animator
            }
            
            Collider2D[] hitTargets = Physics2D.OverlapCircleAll(transform.position, 1f); // radius can change if needed

            /*foreach (Collider2D target in hitTargets)
            {
                // Assuming your target has an hp script/component
                hp targetHp = target.GetComponent<hp>();
                if (targetHp != null)
                {
                    targetHp.TakeDamage(currentWpn.damage); // Use the weapon's damage value
                }
            }*/
        }
    }

    void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            Debug.Log(playerName + " has died.");
            // Disable movement and play death animation
            body.velocity = Vector2.zero;
            if (motion != null)
            {
                motion.SetTrigger("die");
            }
        }
    }

    // Optional: Add Gizmos to show the attack range
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
