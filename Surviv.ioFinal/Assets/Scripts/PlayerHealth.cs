using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public Slider healthSlider;  

    void Update()
    {
        if (healthSlider == null)
        {
            Debug.LogError("Health Slider is not assigned!");
        }

        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health: " + health); 
    }

    void Die()
    {
        Debug.Log("Player Died");

        SceneManager.LoadScene("GameOver");
    }
}
