using System.Collections;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weapon; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable or comment out the following lines if PickUpWeapon is not yet defined
            // WeaponSwitching weaponSwitching = other.GetComponent<WeaponSwitching>();
            // if (weaponSwitching != null)
            // {
            //     weaponSwitching.PickUpWeapon(weapon);
            //     gameObject.SetActive(false); // Deactivate the pickup object
            // }
        }
    }
}
