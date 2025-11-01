using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25; // Damage yang diberikan oleh peluru
    public float speed = 10f;

    void Update()
    {
        // Gerakkan peluru ke depan
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            // Tambah score
            if (ScoreManager.instance != null)
                ScoreManager.instance.AddScore(10);  // Nilai bisa diatur
        }
    }

}
