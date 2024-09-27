using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnDefeated()
    {
        float dropChance = 0.03f; // 3% chance
        if (Random.value < dropChance)
        {
            // Drop a health power-up
            Debug.Log("Health power-up dropped!");
        }
    }
}
