using UnityEngine;

public class EvilCharacter : MonoBehaviour
{
    public float movementSpeed = 100f;
    public float attackRange = 10f;
    public float attackDamage = 10f;

    private Transform player;
    private bool isGood = false;
    
    /*
    public Color goodColor = Color.green;
    */


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isGood) // Only move or attack if not "good"
        {
            if (Vector3.Distance(transform.position, player.position) > attackRange)
            {
                //transform.LookAt(player);
                transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                AttackPlayer();
            }
        }
    }

    void AttackPlayer()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    public void Goodify(Color goodColor)
    {
        
        Debug.Log("Goodify method called");
        isGood = true;
        GetComponent<Renderer>().material.color = goodColor;
        Debug.Log("Character color changed to " + goodColor);
        // Stop chasing or attacking the player
        // Optionally, you could disable the EvilCharacter's movement or attack components here
        enabled = false;
    }
}