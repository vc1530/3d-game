using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //Debug.Log("Current Health: " + currentHealth);
        // Check if the player's health drops below 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement game over logic here
        //Debug.Log("Player died!");
        // For example, you could show a game over screen, restart the level, etc.
    }
}