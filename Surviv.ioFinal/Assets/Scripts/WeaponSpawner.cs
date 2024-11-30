using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject[] weapons; 
    public Transform[] spawnPoints; 
    public float spawnInterval = 10f;
    public bool respawnWeapons = true; 

    private List<GameObject> spawnedWeapons = new List<GameObject>();

    void Start()
    {
        SpawnAllWeapons();

        if (respawnWeapons)
        {
            StartCoroutine(RespawnRoutine());
        }
    }

    void SpawnAllWeapons()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            SpawnWeaponAtPoint(spawnPoint);
        }
    }

    void SpawnWeaponAtPoint(Transform spawnPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Weapon"))
            {
                return; 
            }
        }

        // Randomly select a weapon
        int randomIndex = Random.Range(0, weapons.Length);
        GameObject weapon = Instantiate(weapons[randomIndex], spawnPoint.position, spawnPoint.rotation);
        weapon.tag = "Weapon"; 
        spawnedWeapons.Add(weapon);
    }

    IEnumerator RespawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnAllWeapons();
        }
    }
}
