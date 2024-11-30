using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public enum AmmoType { NineMM, TwelveGauge, Five56MM }
    public AmmoType ammoType;
    public int ammoAmount = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddAmmo(ammoType, ammoAmount);
                Destroy(gameObject);
            }
        }
    }
}
