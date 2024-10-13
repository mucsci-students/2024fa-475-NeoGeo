using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpHeight = 1.0f;
    public Weapon weapon;
    private Rigidbody2D rb;
    private Animator motion;
    private bool isAlive;
    public string playerName = "Girard";
    private float moveX;
    private float moveY;
    private PlayerHealth hp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        motion = GetComponent<Animator>();
        isAlive = true; // Set isAlive to true initially
        hp = GetComponent<PlayerHealth>();

        // Subscribe to health changes
        hp.onHealthChangedCallback += OnHealthChanged;
    }

    void OnDestroy()
    {
        // Unsubscribe from health changes to avoid memory leaks
        if (hp != null)
        {
            hp.onHealthChangedCallback -= OnHealthChanged;
        }
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            HandleMovement();
        }
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void HandleMovement()
    {
        Vector2 velocity = new Vector2(moveX * speed, rb.velocity.y);
        rb.velocity = velocity;

        if (Mathf.Abs(velocity.x) > 0.01f)
        {
            motion.SetBool("isMoving", true);
            transform.localScale = new Vector3(Mathf.Sign(moveX) * 0.8f, 0.8f, 0.8f);
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
        motion.SetBool("isProjectile", weapon != null && weapon.isProjectile);

        if (motion != null)
        {
            motion.SetTrigger("Attack");
        }
    }

    void Die()
    {
        if (!isAlive) return;

        isAlive = false;
        Debug.Log(playerName + " has died.");
        rb.velocity = Vector2.zero;
        if (motion != null)
        {
            motion.SetTrigger("die");
        }
    }

    void OnHealthChanged()
    {
        // Optionally, update character behavior based on health
        if (hp.Health <= 0)
        {
            Die();
        }
    }

}
