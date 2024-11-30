using System.Collections;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime; 
    }

    public void TryShoot()
    {
        if (fireCooldown <= 0)
        {
            Shoot(); 
            fireCooldown = fireRate; 
        }
    }

    void Shoot()
    {
        if (enemyBulletPrefab != null && bulletSpawnPoint != null)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();

            if (bulletScript != null)
            {
            }
        }
    }
}
