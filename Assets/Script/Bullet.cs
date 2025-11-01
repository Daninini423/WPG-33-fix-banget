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
        // Peluru akan hilang setelah mengenai musuh (logika ini sudah di-handle di script enemy)
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);  // Hancurkan peluru setelah kena musuh

            Destroy(gameObject);  // Hancurkan peluru setelah kena musuh
        }
    }
}
