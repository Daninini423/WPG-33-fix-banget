using UnityEngine;

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

}
