using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpHeight = 5.0f;
    public Weapon currentWpn;
    private Rigidbody2D rb;
    private Animator motion;
    private bool isAlive;
    public string playerName = "Girard";
    public int hp = 100;
    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        motion = GetComponent<Animator>();
        isAlive = true; // Set isAlive to true initially
    }

    void FixedUpdate()
    {
        HandleMovement();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal"); // left/right movement (A/D)
        moveY = Input.GetAxis("Vertical"); // up/down movement (W/S)
        if (hp <= 0)
            Die();
        if (Input.GetMouseButtonDown(0)) // Left mouse button to attack
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            motion.SetTrigger("Jump");
        }

    }

    void HandleMovement()
    {

        Vector2 velocity = new Vector2(moveX * speed, moveY * speed);
        rb.velocity = velocity;

        if (velocity.sqrMagnitude > 0.01f && motion != null) // Using sqrMagnitude to compare without needing to use Mathf.Sqrt
        {
        motion.SetBool("isMoving", true);
            if (moveX != 0)
            {
                transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1); // Flip sprite based on direction
            }
        }
        else
        {
            motion.SetBool("isMoving", false);
        }
    }

    void Attack()
    {
        motion.SetBool("isArmed", currentWpn!=null); //sets animation for armed attack or not
        motion.SetBool("Charge", (currentWpn!=null && currentWpn.isProjectile)); //projectiles charge until mouse release to shoot arrow
            
            if (motion != null)
            {
                motion.SetTrigger("Attack");
            }
        
        
    }


    void Die()
    {
        if (isAlive)
        {
            isAlive = false;
            Debug.Log(playerName + " has died.");
            // Disable movement and play death animation
            rb.velocity = Vector2.zero;
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
