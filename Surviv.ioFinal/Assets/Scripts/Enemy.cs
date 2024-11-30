using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy took damage: " + damage + ", remaining health: " + (health - damage));
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died: " + gameObject.name);
        Destroy(gameObject);
    }
}
