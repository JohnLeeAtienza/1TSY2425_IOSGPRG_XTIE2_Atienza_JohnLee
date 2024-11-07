using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; 
    public float fireRate = 0.5f;
    private float fireCooldown = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0) && fireCooldown <= 0)
        {
            Shoot();
            fireCooldown = fireRate;
        }
        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

        Vector3 shootDirection = (mousePosition - bulletSpawnPoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Initialize(shootDirection);
    }
}
