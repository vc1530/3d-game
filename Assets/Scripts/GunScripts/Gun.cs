using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;

    private float timeSinceLastShot;
    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
    }

    public void StartReload()
    {
        if (!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        gunData.reloading = false;
    }
    
    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);
    // ReSharper disable Unity.PerformanceAnalysis
    public void Shoot()
    {
        if (gunData.currentAmmo > 0)
        {
            if (CanShoot())
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(muzzle.position, transform.forward, out hitInfo, gunData.maxDistance)) ;
                {
                    var damageable = hitInfo.transform.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.Damage(gunData.damage);
                    }
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        Debug.DrawRay(muzzle.position,muzzle.forward);
    }

    private void OnGunShot()
    {
        Destroy(gameObject);
    }
    
}
