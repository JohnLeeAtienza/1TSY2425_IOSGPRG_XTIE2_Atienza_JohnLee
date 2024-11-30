using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public float lifetime = 5f;
    private Transform playerTransform;
    private Vector3 shootDirection;
    private Rigidbody2D rb;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject, lifetime); 

        rb = GetComponent<Rigidbody2D>(); 

        if (playerTransform != null)
        {
            shootDirection = (playerTransform.position - transform.position).normalized; 
            RotateTowardsPlayer(); 
        }

        rb.velocity = shootDirection * speed; 
    }

    void Update()
    {
    }

    void RotateTowardsPlayer()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); 
            }
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); 
        }
    }
}
