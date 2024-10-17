using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float speed = 3.0f;
    public float jumpHeight = 2.0f;
    public Weapon weapon; // Reference to the current weapon equipped

    private Rigidbody2D rb;
    private Animator motion;
    private bool isAlive;
    public string playerName = "Girard";
    private float moveX;
    private float moveY;
    public PlayerHealth hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        motion = GetComponent<Animator>();
        isAlive = true; // Set isAlive to true initially
        hp = GetComponent<PlayerHealth>();

        // Subscribe to health changes
        hp.onHealthChangedCallback += OnHealthChanged;
    }

    void Update()
    {
        if (!isAlive) return;

        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0)) // Left mouse button to attack
        {
            Attack();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.L)) //testing
        {
            hp.TakeDamage(10);
        }
        
        else if (Input.GetKeyDown(KeyCode.Q) && weapon != null) // Check if there's a weapon to drop
        {
            DropWeapon(); // Call the DropWeapon method
        }

        // Update weapon sorting based on player's direction
        UpdateWeaponSorting();
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            HandleMovement();
        }
    }

    void HandleMovement()
    {
        // Use the speed variable directly for movement calculation
        float weaponWeight = weapon != null ? weapon.weight : 0f;
        float effectiveSpeed = speed - (weaponWeight * 0.1f); // Adjust the factor as needed

        // Calculate the movement vector
        Vector2 movement = new Vector2(moveX * effectiveSpeed, moveY * effectiveSpeed);

        rb.velocity = movement;

        // Update animation states
        if (movement.magnitude > 0.01f)
        {
            motion.SetBool("isMoving", true);
            // Flip character based on horizontal movement direction
            if (moveX != 0)
            {
                transform.localScale = new Vector3(Mathf.Sign(moveX) * 0.8f, 0.8f, 0.8f);
            }
        }
        else
        {
            motion.SetBool("isMoving", false);
        }
    }



    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            motion.SetTrigger("Jump");
        }
    }

    void Attack()
    {
        motion.SetBool("isArmed", weapon != null);

        if (motion != null & weapon != null)
        {
            motion.SetTrigger("Attack");
            weapon.Slash();
        }
        else
            motion.SetTrigger("Attack");

    }

    void DropWeapon()
    {
        if (weapon != null)
        {
            PickUpController pickUpController = weapon.GetComponent<PickUpController>();
            if (pickUpController != null)
            {
                pickUpController.Drop(); 
                weapon = null; 
            }
        }
    }

    void UpdateWeaponSorting()
    {
        if (weapon != null)
        {
            SpriteRenderer weaponRenderer = weapon.GetComponent<SpriteRenderer>();
            weaponRenderer.sortingLayerName = "Player";
            if (moveX > 0) // Facing right
            {
                weaponRenderer.sortingOrder = 3;
            }
            else if (moveX < 0) // Facing left
            {
                weaponRenderer.sortingOrder = -1; 
            }

            Vector3 weaponOffset = new Vector3(0.3f, -1.2f, 0f);

            float bounceAmount = 0.07f; // ### Keep Between 0.05 - 0.1 ### otherwise its looks hilarious
            float bounceSpeed = 20f;  /** default 20 */
            if (Mathf.Abs(moveX) > 0.01f) //
            {
                float move = Mathf.Sin(Time.time * bounceSpeed) * bounceAmount;
                weapon.transform.localPosition = weaponOffset + new Vector3(0, move, 0);
            }
            else
            {
                weapon.transform.localPosition = weaponOffset;
            }
        }
    }

    void Die()
    {
        isAlive = false;
        Debug.Log(playerName + " has died.");
        rb.velocity = Vector2.zero;
        if (motion != null)
        {
            motion.SetTrigger("Die");
        }
    }

    void OnHealthChanged()
    {
        // Optionally, update character behavior based on health
        if (hp.health <= 0)
        {
            Die();
            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Check if the collided object's tag is "Player"
        if (col.gameObject.CompareTag("Attack"))
        {
            Debug.Log("Player is being attacked");

    
                // Get the script component that has the TakeDamage method
                var playerHealth = col.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(10); // Call the TakeDamage method
                }

            }
        }
    }
