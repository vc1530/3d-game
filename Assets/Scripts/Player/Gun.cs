using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /*
    public Camera playerCamera;
    */
    public LayerMask evilLayerMask;
    public Color goodColor = Color.green;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        print("shoot");
        RaycastHit hit;
        Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);

        
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, evilLayerMask))
        {
            if (hit.collider.CompareTag("EvilCharacter"))
            {
                print("hit"); 
                Destroy(bullet, .5f); 
                hit.collider.GetComponent<EvilCharacter>().Goodify();
            }
        }
        
        /*Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, evilLayerMask))
        {
            if (hit.collider.CompareTag("EvilCharacter"))
            {
                hit.collider.GetComponent<EvilCharacter>().Goodify(goodColor);
            }
        }*/

        // Spawn bullet
        
    }
}