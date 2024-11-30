using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Handgun,
    Shotgun,
    AssaultRifle
}

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    public int damage = 10;
    public int ammoPerShot = 1;  
    public float reloadTime;
    private float fireCooldown = 0f;

    public WeaponType weaponType;
    private PlayerController playerController;  

    public int bulletsPerShot = 5;  
    public float spreadAngle = 30f; 

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;
    }

    public void TryShoot()
    {
        if (fireCooldown <= 0 && HasAmmo())
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    bool HasAmmo()
    {
        switch (weaponType)
        {
            case WeaponType.Handgun:
                return playerController.ammo9mm > 0;
            case WeaponType.Shotgun:
                return playerController.ammo12Gauge > 0;
            case WeaponType.AssaultRifle:
                return playerController.ammo556mm > 0;
            default:
                return false;
        }
    }

    void Shoot()
    {
        switch (weaponType)
        {
            case WeaponType.Shotgun:
                ShootShotgun();
                break;

            case WeaponType.Handgun:
                ShootHandgun();
                break;

            case WeaponType.AssaultRifle:
                ShootAssaultRifle();
                break;
        }
    }

    void ShootShotgun()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            float angle = Random.Range(-spreadAngle / 2, spreadAngle / 2);
            Vector3 shootDirection = GetShootDirection(angle);

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Bullet>().Initialize(shootDirection, damage);
        }
    }

    void ShootHandgun()
    {
        Vector3 shootDirection = bulletSpawnPoint.up;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Bullet>().Initialize(shootDirection, damage);
    }

    void ShootAssaultRifle()
    {
        Vector3 shootDirection = bulletSpawnPoint.up;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Bullet>().Initialize(shootDirection, damage);
    }

    Vector3 GetShootDirection(float angle)
    {
        return Quaternion.Euler(0, 0, angle) * bulletSpawnPoint.up;
    }
}
