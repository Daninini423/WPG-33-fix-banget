/*using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 200;

    void Start()
    {
        Debug.Log($"[ENEMY START] {name} punya health awal: {health}");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"[{name}] HP sebelum: {health}");
        health -= damage;
        Debug.Log($"[{name}] Kena damage {damage}, sisa HP: {health}");

        if (health <= 0)
        {
            Debug.Log($"[{name}] Mati, memanggil Die()");
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}*/

// iki modifikasi ku dan
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public WaveEnemySpawner spawner; // akan dicari otomatis di scene

    public int health = 100;

    private void Start()
    {
        // Jika spawner belum di-assign secara manual
        if (spawner == null)
        {
            spawner = FindObjectOfType<WaveEnemySpawner>(); // cari otomatis di scene
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (spawner != null)
        {
            spawner.OnEnemyKilled();
        }
        else
        {
            Debug.LogWarning("EnemySpawner tidak ditemukan oleh " + gameObject.name);
        }

        Destroy(gameObject);
    }
}

