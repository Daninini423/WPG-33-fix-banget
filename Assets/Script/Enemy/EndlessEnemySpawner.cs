using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab; // Prefab musuh yang akan di-spawn

    [SerializeField]
    private float _minimumSpawnTime = 1f; // Waktu minimum antar spawn (detik)

    [SerializeField]
    private float _maximumSpawnTime = 3f; // Waktu maksimum antar spawn (detik)

    private float _timeUntilSpawn; // Waktu yang tersisa hingga spawn berikutnya

    void Awake()
    {
        // Set waktu spawn awal
        SetTimeUntilSpawn();
    }

    void Update()
    {
        // Kurangi waktu hingga spawn
        _timeUntilSpawn -= Time.deltaTime;

        // Jika waktu untuk spawn telah habis
        if (_timeUntilSpawn <= 0)
        {
            SpawnEnemy(); // Spawn musuh
            SetTimeUntilSpawn(); // Atur ulang waktu spawn
        }
    }

    private void SpawnEnemy()
    {
        // Instansiasi musuh di posisi spawner
        Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        Debug.Log("Spawned enemy: " + _enemyPrefab.name); // Log untuk debugging
    }

    private void SetTimeUntilSpawn()
    {
        // Atur waktu spawn dengan nilai acak dalam rentang yang ditentukan
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
        Debug.Log("Next spawn in: " + _timeUntilSpawn + " seconds"); // Log waktu spawn berikutnya
    }
}
