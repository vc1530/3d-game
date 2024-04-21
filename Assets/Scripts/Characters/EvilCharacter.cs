using UnityEngine;
using UnityEditor;

public class EvilCharacter : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float attackRange = 1f;
    public float attackDamage = 10f;

    private Transform player;
    private bool isGood = false;

    private bool isAttacking = false;
    private Rigidbody rb;

    public GameObject goodCharacter; 
    public Transform goodCharacterTransform;

    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("EvilCharacter").GetComponent<AudioManager>();
        
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //if (!isGood) // Only move or attack if not "good"
        //{
        //    if (Vector3.Distance(transform.position, player.position) > attackRange)
        //    {
        //        //transform.LookAt(player);
        //        //transform.Translate(transform.forward * movementSpeed * Time.deltaTime);
        //        //transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        //    }
        //    else
        //    {
        //        AttackPlayer();
        //    }
        //}

        if (!isGood && player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = player.position - transform.position;

            // Move towards the player
            rb.velocity = direction.normalized * movementSpeed;

            // Check if the enemy is within attack range
            if (direction.magnitude <= attackRange && !isAttacking)
            {
                // Attack the player
                Debug.Log(attackRange + "direction:" + direction.magnitude);
                movementSpeed = 0;
                AttackPlayer();
            }
            else
            {
                // Stop attacking
                isAttacking = false;
            }

            // Rotate the enemy to face the player
            transform.LookAt(player);
        }
    }

    void AttackPlayer()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    public void Goodify()
    {

        print("goodifying"); 
        isGood = true;

        gameObject.SetActive(false); 
        goodCharacterTransform.position = transform.position; 
        goodCharacter.SetActive(true); 

    }
}