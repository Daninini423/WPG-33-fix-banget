using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    // Fungsi untuk menerima damage
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die(); // Hancurkan musuh jika health <= 0
        }
    }

    // Fungsi untuk menghancurkan musuh
    void Die()
    {
        Destroy(gameObject);  // Menghilangkan musuh dari scene
    }
}
