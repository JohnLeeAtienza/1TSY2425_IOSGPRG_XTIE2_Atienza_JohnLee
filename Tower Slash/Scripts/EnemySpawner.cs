using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Assign all enemy prefabs, including RotatingArrowPrefab
    public float spawnInterval = 4.5f;
    public float spawnHeight = 1f;
    public int maxEnemiesToSpawn = 5;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (maxEnemiesToSpawn <= 0) return;

        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject selectedPrefab = enemyPrefabs[randomIndex];
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + spawnHeight, 0f);

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);

        maxEnemiesToSpawn--;
    }
}
