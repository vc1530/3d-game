// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Gun : MonoBehaviour
// {
//     public Camera playerCamera = Camera.main;
//     public LayerMask evilLayerMask;
//     public Color goodColor = Color.green;
//     public Transform bulletSpawnPoint;
//     public GameObject bulletPrefab;
//     public float bulletSpeed = 10;

//     void Update()
//     {
//         if (Input.GetMouseButtonDown(0))
//         {
//             Shoot();
//         }
//     }

//     void Shoot()
//     {
//         print("shoot");
//         RaycastHit hit;
//         Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);

        
//         GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//         Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
//         if (bulletRigidbody != null)
//         {
//             bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
//         }

//         if (Physics.Raycast(ray, out hit, Mathf.Infinity, evilLayerMask))
//         {
//             if (hit.collider.CompareTag("EvilCharacter"))
//             {
//                 print("hit"); 
//                 Destroy(bullet, .5f); 
//                 hit.collider.GetComponent<EvilCharacter>().Goodify();
//             }
//         }

//         // Get the direction from the gun to the point the camera is looking at
//         Vector3 targetDirection = playerCamera.transform.forward;

//         // Create a rotation that points the gun's forward direction in the target direction
//         Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

//         // Apply the rotation to the gun
//         transform.rotation = targetRotation;
    
//         /*Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

//         if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, evilLayerMask))
//         {
//             if (hit.collider.CompareTag("EvilCharacter"))
//             {
//                 hit.collider.GetComponent<EvilCharacter>().Goodify(goodColor);
//             }
//         }*/

//         // Spawn bullet
        
//     }
// }

// using UnityEngine;

// public class Gun : MonoBehaviour
// {
//     public LayerMask evilLayerMask;
//     // Reference to the bullet prefab
//     public GameObject bulletPrefab;
//     public float bulletSpeed = 10;
//     public Transform bulletSpawnPoint;
    
//     public AudioManager audioManager;

//     public float shootingCooldown = 0.2f;
//     private float shootingCooldownTimer = 0f;

//     private void Awake()
//     {
//         audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
//     }


//     void Update()
//     {
//         // Decrease the shooting cooldown timer
//         shootingCooldownTimer -= Time.deltaTime;

//         // Check if the player pressed the fire button (e.g., left mouse button)
//         if (Input.GetMouseButtonDown(0) && shootingCooldownTimer <= 0f)
//         {
//             // Spawn a bullet
//             Shoot();
            
//             // Reset the shooting cooldown timer
//             shootingCooldownTimer = shootingCooldown;
//         }
//     }

//     void Shoot()
//     {
//         print("shoot");
//         audioManager.PlaySFX(audioManager.fart);
//         RaycastHit hit;
//         Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);

        
//         GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
//         Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
//         if (bulletRigidbody != null)
//         {
//             // Create a bullet instance at the bullet spawn point's position and rotation
//             GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            
//             // Get the direction from the camera to the mouse cursor
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hit;
//             Vector3 targetDirection;

//             // Check if the raycast hits something in the scene
//             if (Physics.Raycast(ray, out hit))
//             {
//                 // Set the target direction to the point where the raycast hit
//                 targetDirection = hit.point - bulletSpawnPoint.position;
//             }
//             else
//             {
//                 // If the raycast doesn't hit anything, set the target direction to the direction of the ray
//                 targetDirection = ray.direction;
//             }

//             // Rotate the bullet to face the target direction
//             bullet.transform.rotation = Quaternion.LookRotation(targetDirection);

//             // Apply force to the bullet in the forward direction
//             bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed; // Adjust the speed as needed

//             if (Physics.Raycast(ray, out hit, Mathf.Infinity, evilLayerMask))
//             {
//                 if (hit.collider.CompareTag("EvilCharacter"))
//                 {
//                     print("hit"); 
//                     Destroy(bullet, .5f); 
//                     hit.collider.GetComponent<EvilCharacter>().Goodify();
//                 }
//             }
//         }
//         else
//         {
//             Debug.LogError("Bullet prefab or bullet spawn point is not assigned!");
//         }
//     }
// }

using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming Fire1 is the left mouse button
        {
            FireBullet();
        }
    }

    /*void FireBullet()
    {
        // Get the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        
        // Calculate the direction from the bullet spawn point to the center of the screen
        Vector3 shootDirection = Camera.main.ScreenToWorldPoint(screenCenter) - bulletSpawnPoint.position;
        shootDirection.Normalize();

        // Instantiate the bullet at the bullet spawn point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        
        // Get the bullet's Rigidbody component and apply velocity in the calculated direction
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = shootDirection * bulletSpeed;
        }
    }*/
    
    /*void FireBullet()
    {
        // Get the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        
        // Calculate the direction from the bullet spawn point to the center of the screen
        Vector3 aimDirection = Camera.main.ScreenToWorldPoint(screenCenter) - bulletSpawnPoint.position;
        aimDirection.Normalize();

        // Instantiate the bullet at the bullet spawn point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        
        // Get the bullet's Rigidbody component
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Apply velocity in the forward direction (from the tip of the gun)
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        // Rotate the bullet to face towards the center of the screen
        bullet.transform.LookAt(Camera.main.transform.position);
    }*/
    
    void FireBullet()
    {
        // Get the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // Calculate the direction from the bullet spawn point to the center of the screen
        Vector3 aimDirection = Camera.main.ScreenToWorldPoint(screenCenter) - bulletSpawnPoint.position;
        aimDirection.Normalize();

        // Instantiate the bullet at the bullet spawn point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the bullet's Rigidbody component
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Apply velocity in the direction towards the center of the screen
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = -aimDirection * bulletSpeed;
        }
    }
    
}

    /*// Reference to the bullet prefab
    public GameObject bulletPrefab;

    // Reference to the bullet spawn point
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 15f; 

    // Shooting cooldown time (in seconds)
    public float shootingCooldown = 0.2f;
    private float shootingCooldownTimer = 0f;

    public AudioManager audioManager;

    private void Awake() { 
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); 
    }

    void Update()
    {
        // Decrease the shooting cooldown timer
        shootingCooldownTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

        // Check if the player pressed the fire button (e.g., left mouse button)
        /*if (Input.GetMouseButtonDown(0) && shootingCooldownTimer <= 0f)
        {
            // Spawn a bullet
            Shoot();
            
            // Reset the shooting cooldown timer
            shootingCooldownTimer = shootingCooldown;
        }#1#
    }

    public void Fire()
    {
        if (shootingCooldownTimer <= 0f)
        {
            // spawn a bullet
            Shoot();
            // resey the shooting cooldown time
            shootingCooldownTimer = shootingCooldown;
        }
    }

    void Shoot()
    {
        audioManager.PlaySFX(audioManager.fart);
        // Check if the bullet prefab and spawn point are assigned
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Create a bullet instance at the bullet spawn point's position and rotation
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            
            // Get the direction from the camera to the mouse cursor
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 targetDirection;

            // Check if the raycast hits something in the scene
            if (Physics.Raycast(ray, out hit))
            {
                // Set the target direction to the point where the raycast hit
                targetDirection = hit.point - bulletSpawnPoint.position;
            }
            else
            {
                // If the raycast doesn't hit anything, set the target direction to the direction of the ray
                targetDirection = ray.direction;
            }

            // Rotate the bullet to face the target direction
            bullet.transform.rotation = Quaternion.LookRotation(targetDirection);

            // Apply force to the bullet in the forward direction
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed; // Adjust the speed as needed

            /*if (hit.collider.CompareTag("EvilCharacter"))
            {
                print("hit"); 
                Destroy(bullet, .5f); 
                hit.collider.GetComponent<EvilCharacter>().Goodify();
            }#1#
        }
        else
        {
            Debug.LogError("Bullet prefab or bullet spawn point is not assigned!");
        }
    }*/
