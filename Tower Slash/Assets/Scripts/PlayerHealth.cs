using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Handle player death
            Debug.Log("Player is dead!");
        }
    }

    public void AddHealth(int health)
    {
        currentHealth = Mathf.Min(currentHealth + health, maxHealth);
    }
}
