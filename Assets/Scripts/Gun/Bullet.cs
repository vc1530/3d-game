using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float lifeTime = 3f;

    /*private void Start()
    {
        DestroyBulletAfterDelay();
    }*/

    /*private void OnCollisionEnter(Collision collision)
    {
        print("collision"); 
        
        if (collision.collider.CompareTag("EvilCharacter"))
        {
            print("hit evil character"); 
            EvilCharacter evilCharacter = collision.collider.GetComponent<EvilCharacter>();
            if (evilCharacter != null)
            {
                evilCharacter.Goodify();
            }
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EvilCharacter"))
        {
            Destroy(gameObject);
            other.GetComponent<EvilCharacter>().Goodify();
        }
    }

    /*private void DestroyBulletAfterDelay()
    {
        Destroy(gameObject,lifeTime);
    }*/
}
