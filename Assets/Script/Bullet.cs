using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    private bool hasHit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;
        hasHit = true;

        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);

                //  Tambahkan efek kena hit merah
                EnemyHitFeedback feedback = enemy.GetComponent<EnemyHitFeedback>();
                if (feedback != null)
                    feedback.TakeHit();
            }
        }

        Destroy(gameObject);
    }
}
