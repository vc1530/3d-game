using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 5000f;
    public float currentHealth;
    public HealthBar healthBar;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetSlider(currentHealth);
        print(currentHealth); 
        // Check if the player's health drops below 0
        if (currentHealth <= 0)
        {
            Scene thisScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(thisScene.name);
            //Die();
        }
    }

    void Die()
    {
        // Implement game over logic here
        //Debug.Log("Player died!");
        // For example, you could show a game over screen, restart the level, etc.
    }
}