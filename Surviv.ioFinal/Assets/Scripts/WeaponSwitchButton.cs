using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponSwitchButton : MonoBehaviour
{
    public GameObject[] allWeapons;
    public TMP_Text weaponText; 

    private List<GameObject> unlockedWeapons = new List<GameObject>(); 
    private int currentWeaponIndex = 0; 

    void Start()
    {
        foreach (GameObject weapon in allWeapons)
        {
            unlockedWeapons.Add(weapon);
            weapon.SetActive(false); 
        }

        if (unlockedWeapons.Count > 0)
        {
            unlockedWeapons[0].SetActive(true);
        }

        UpdateWeaponText();
    }

    public void SwitchWeapon()
    {
        if (unlockedWeapons.Count == 0)
        {
            Debug.LogWarning("No weapons to switch to.");
            return;
        }

        unlockedWeapons[currentWeaponIndex].SetActive(false);

        currentWeaponIndex = (currentWeaponIndex + 1) % unlockedWeapons.Count;

        unlockedWeapons[currentWeaponIndex].SetActive(true);

        UpdateWeaponText();
    }

    private void UpdateWeaponText()
    {
        if (unlockedWeapons.Count > 0)
        {
            string weaponName = unlockedWeapons[currentWeaponIndex].name;
            weaponText.text = "Current Weapon: " + weaponName;
        }
        else
        {
            weaponText.text = "No Weapons Available";
        }
    }
}
