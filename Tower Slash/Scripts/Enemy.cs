using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private DashGauge dashGauge;

    void Start()
    {
        dashGauge = FindObjectOfType<DashGauge>();
    }

    public void OnDefeated()
    {
        float dropChance = 0.03f;
        if (Random.value < dropChance)
        {
            Debug.Log("Health power-up dropped!");
        }

        if (dashGauge != null)
        {
            dashGauge.IncreaseDash();
        }

        Destroy(gameObject);
    }
}
