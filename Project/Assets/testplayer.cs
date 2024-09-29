using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public Sprite playerSprite;
    public float speed = 5.0f; // Speed for left/right movement
    public float jumpForce = 10.0f; // Force applied when jumping
    public GameObject weapon; // Player's weapon

    private Rigidbody2D body; // Removed new keyword
    private Animator botAnimator; // Removed new keyword

    private bool isAlive;
    public string playerName = "Girard";
    public int hp = 100;
    public GameObject armor;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        botAnimator = GetComponent<Animator>();
        armor = gameObject;
        isAlive = true; // Set isAlive to true initially
    }

    void Update()
    {
        HandleMovement();
        HandleJump();

        if (hp <= 0)
            Die();
        else if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Slash();
        }
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get input for left/right movement
        Vector2 velocity = body.velocity;
        velocity.x = horizontalInput * speed;
        body.velocity = velocity;

        if (horizontalInput != 0 && botAnimator != null)
        {
            botAnimator.SetBool("isRunning", true);
        }
        else if (botAnimator != null)
        {
            botAnimator.SetBool("isRunning", false);
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(body.velocity.y) < 0.01f) // Press Space to jump
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (botAnimator != null)
            {
                botAnimator.SetTrigger("jump");
            }
        }
    }

    void Slash()
    {
        if (weapon != null)
        {
            // Add logic for the weapon's slash, for now, we can just log it
            Debug.Log(playerName + " slashes with " + weapon.name);
        }
        else
        {
            Debug.LogWarning("No weapon assigned!");
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
            if (botAnimator != null)
            {
                botAnimator.SetTrigger("die");
            }
        }
    }
}

