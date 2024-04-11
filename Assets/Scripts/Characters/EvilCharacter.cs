using UnityEngine;

public class EvilCharacter : MonoBehaviour
{
    public float movementSpeed = 100f;
    public float attackRange = 10f;
    public float attackDamage = 10f;

    private Transform player;
    private bool isGood = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<Renderer>().material.color = Color.red;
    }

    void Update()
    {
        if (!isGood) // Only move or attack if not "good"
        {
            if (Vector3.Distance(transform.position, player.position) > attackRange)
            {
                transform.LookAt(player);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
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
        isGood = true;
        GetComponent<Renderer>().material.color = goodColor;
        // Stop chasing or attacking the player
        // Optionally, you could disable the EvilCharacter's movement or attack components here
        enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGood && collision.collider.CompareTag("EvilCharacter"))
        {
            // Turn the "good" character back to evil
            isGood = false;
            GetComponent<Renderer>().material.color = Color.red; // Change to your original evil color
            // Optionally, you could re-enable movement or attack components here
            enabled = true;
        }
    }
}