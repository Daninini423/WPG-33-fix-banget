using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage = 25; // jumlah damage per serangan

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage); // kurangi health musuh

                // Tambahkan efek kena hit (jika kamu punya EnemyHitFeedback.cs)
                var feedback = other.GetComponent<EnemyHitFeedback>();
                if (feedback != null)
                    feedback.TakeHit();

                // Tambah skor jika musuh mati
                if (enemy.health <= 0 && ScoreManager.instance != null)
                    ScoreManager.instance.AddScore(10);
            }
        }
    }
}
