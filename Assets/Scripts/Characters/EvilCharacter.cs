using UnityEngine;
using UnityEditor;

public class EvilCharacter : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float attackRange = 5f;
    public float attackDamage = 10f;

    private Transform player;
    public bool isGood = false;

    private bool isAttacking = false;
    private Rigidbody rb;

    public GameObject goodCharacter; 
    public Transform goodCharacterTransform;

    public LayerMask groundLayer; 

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
        if (gameObject.name != "GiantOne") { 
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                // Move the character to the point where the ray hit the ground.
                transform.position = hit.point;
            }
        }

        if (!isGood && player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = player.position - transform.position;

            print("Direction" + direction.magnitude); 
            if (direction.magnitude <= attackRange)
            {
                // Attack the player
                Debug.Log(attackRange + "direction:" + direction.magnitude);
                rb.velocity = direction.normalized * movementSpeed;

            }
            else
            {
                print("else no movement"); 
                rb.velocity = Vector3.zero; 
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