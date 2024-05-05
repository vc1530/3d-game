using UnityEngine;
using UnityEditor;
using UnityEngine.AI; 

public class EvilCharacter : MonoBehaviour
{
    // public float movementSpeed = 2f;
    public float attackRange = 5f;
    public float attackDamage = 1f;

    private Transform player;
    //public bool isGood = false;

    //private bool isAttacking = false;
    //private Rigidbody rb;

    public GameObject goodCharacter; 
    public Transform goodCharacterTransform;

    public LayerMask groundLayer; 

    public AudioManager audioManager;

    private NavMeshAgent agent; 
    private bool isChasingPlayer = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("EvilCharacter").GetComponent<AudioManager>();
        
    }


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.enabled = true; 
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            // Move the character to the point where the ray hit the ground.
            transform.position = hit.point;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            if (!isChasingPlayer)
            {
                isChasingPlayer = true;
                agent.SetDestination(player.position); 
            }
            agent.SetDestination(player.position);
        }
        else { 
            if (isChasingPlayer)
            {
                agent.SetDestination(player.position);
            }
        } 

        transform.LookAt(player); 

    }

    void OnCollisionEnter(Collision col) { 
        if (col.gameObject.CompareTag("Player")) AttackPlayer(); 
    }

    void AttackPlayer()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    public void Goodify()
    {
        print("goodifying"); 
        //isGood = true;

        PlayerMotor.goodCharCounter++;
        print(PlayerMotor.goodCharCounter); 
        gameObject.SetActive(false); 
        goodCharacterTransform.position = transform.position; 
        goodCharacter.SetActive(true); 
    }
}