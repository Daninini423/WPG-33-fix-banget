using UnityEngine;
using System.Collections;
using TMPro;

public class WaveEnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    public Transform[] spawnPoints;

    [Header("Wave Settings")]
    public int currentWave = 1;
    public int baseEnemyCount = 50; // wave 1 = 50, wave 2 = 100, dst
    public float spawnInterval = 0.5f;

    [Header("UI")]
    public TextMeshProUGUI waveText;

    private int totalEnemiesThisWave;
    private int enemiesSpawned;
    private int enemiesKilled;
    private bool isSpawning = false;
    private bool waveInProgress = false; // flag untuk mencegah startNextWave berulang

    private void Start()
    {
        StartWave(currentWave);
    }

    private void Update()
    {
        // Cek jika semua musuh di wave ini sudah mati & wave sudah selesai spawn
        if (!isSpawning && waveInProgress && enemiesKilled >= totalEnemiesThisWave)
        {
            waveInProgress = false; // stop supaya tidak dipanggil terus
            StartCoroutine(StartNextWave());
        }
    }

    private void StartWave(int wave)
    {
        waveInProgress = true; // tandai wave sedang berlangsung
        enemiesSpawned = 0;
        enemiesKilled = 0;
        totalEnemiesThisWave = baseEnemyCount * wave;

        UpdateWaveText();

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        isSpawning = true;

        for (int i = 0; i < totalEnemiesThisWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }

        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject chosenPrefab;

        if (currentWave == 1)
            chosenPrefab = enemyPrefab;
        else if (currentWave == 2)
            chosenPrefab = (Random.value > 0.5f) ? enemyPrefab : enemyPrefab1;
        else
            chosenPrefab = enemyPrefab1;

        GameObject enemy = Instantiate(chosenPrefab, randomPoint.position, Quaternion.identity);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.spawner = this;
        }
    }


    public void OnEnemyKilled()
    {
        enemiesKilled++;
        Debug.Log($"Enemy terbunuh: {enemiesKilled}/{totalEnemiesThisWave}");
    }

    private IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(2f); // jeda 2 detik sebelum wave berikutnya
        currentWave++;
        StartWave(currentWave);
    }

    private void UpdateWaveText()
    {
        if (waveText != null)
            waveText.text = $"Wave: {currentWave}";
    }
}
