using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    public int health;               // Current health
    public int maxHealth = 100;      // Current maximum health
    public int maxTotalHealth = 100; 

    private HealthBarController healthBarController; 
    private Rigidbody2D rb; 

    public float knockbackForce = 2f; 
    public float rotationAmount = 10f; 

    private void Start()
    {
        health = 100; 
        healthBarController = FindObjectOfType<HealthBarController>(); 
        rb = GetComponent<Rigidbody2D>(); 

        if (healthBarController == null)
        {
            Debug.LogError("HealthBarController not found in the scene.");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the player.");
        }


        
        if (onHealthChangedCallback != null)
        {
            onHealthChangedCallback.Invoke();
        }

        healthBarController.UpdateHeartsHUD(); 
    }

    public void Heal(int amount)
    {
        health += amount; 
        ClampHealth(); 
        
        onHealthChangedCallback?.Invoke(); 
        healthBarController.UpdateHeartsHUD(); 
    }

    public void TakeDamage(int damage)
    {
        health = health - damage; // Subtract health

        
        ClampHealth(); 

        onHealthChangedCallback?.Invoke(); 
        healthBarController.UpdateHeartsHUD(); 

        ApplyDamageEffects(); 
    }

    

    private void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth); // Clamp health within bounds
    }

    private void ApplyDamageEffects()
    {
        if (rb != null)
        {
            Vector2 randomForce = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * knockbackForce;
            rb.AddForce(randomForce, ForceMode2D.Impulse);

            float randomRotation = Random.Range(-rotationAmount, rotationAmount);
            rb.MoveRotation(rb.rotation + randomRotation);
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        float timer = 0f;
        if (col.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Player is burning");

            timer += Time.deltaTime;
            if (timer >= 1.0f) 
            {
                var playerHealth = col.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    TakeDamage(5); 
                }

                timer = 0f; 
            }
        }
    }
}
