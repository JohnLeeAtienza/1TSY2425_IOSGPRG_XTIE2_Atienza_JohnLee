using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoot : MonoBehaviour
{
    public Weapon weaponPrefab; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.EquipWeapon(weaponPrefab);
                Destroy(gameObject); 
            }
        }
    }
}
