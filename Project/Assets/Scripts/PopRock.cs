using System.Collections;
using UnityEngine;

public class PopRock : MonoBehaviour
{
    private bool isLit = false; // Changed to false to start with an unlit grenade
    private Transform pos;

    public Rigidbody2D rb;

    private float fusetimer = 5f; // Time until the grenade explodes
    private bool hasExploded = false; // To ensure the grenade only explodes once

    public CircleCollider2D col;

    public EffectAnimation explode; // Assuming this is your explosion effect

    void Start()
    {
        // Get the Rigidbody2D component if not assigned in the inspector
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        // Make sure the Rigidbody2D is kinematic at start
        rb.isKinematic = true; 
    }

    void Update()
    {
        // Check if the grenade is lit and the timer has started
        if (isLit && !hasExploded)
        {
            fusetimer -= Time.deltaTime; // Decrease the timer based on the time passed

            if (fusetimer <= 0f)
            {
                Explode(); // Call the explode method when the timer runs out
            }
        }
    }

    // Call this method to throw the grenade
    public void Throw(Vector2 throwForce)
    {
        isLit = true; // Set the grenade as lit
        rb.isKinematic = false; // Set Rigidbody2D to dynamic to allow physics
        rb.AddForce(throwForce, ForceMode2D.Impulse); // Apply throwing force
        StartCoroutine(StartFuse()); // Start the fuse timer
    }

    private IEnumerator StartFuse()
    {
        // Wait for the fuse timer duration
        yield return new WaitForSeconds(5f);
        Explode(); // Explode after 5 seconds
    }

    private void Explode()
    {
        if (!hasExploded)
        {
            hasExploded = true; // Ensure it only explodes once
            col.enabled = false; // Disable the collider to prevent further interactions
            rb.isKinematic = true; // Make it kinematic again if needed

            // Instantiate or activate explosion effect
            if (explode != null)
            {
                Instantiate(explode, transform.position, Quaternion.identity);
            }

            // Optional: Destroy the grenade object after explosion
            Destroy(gameObject, 2f); // Adjust the delay as needed for the explosion effect to play
        }
    }
}
