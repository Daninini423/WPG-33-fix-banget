using UnityEngine;

public class Sword : MonoBehaviour
{

    // Deteksi musuh yang terkena serangan
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();

            if (enemy != null)
            {
                Destroy(other.gameObject);

                // Tambah score
                if (ScoreManager.instance != null)
                    ScoreManager.instance.AddScore(10);
            }
        }
    }

}

