using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Bullet Settings")]
    public Transform firePoint;         // posisi tembakan
    public GameObject bulletPrefab;     // prefab peluru
    public float bulletSpeed = 10f;     // kecepatan peluru
    public float bulletLifetime = 3f;   // waktu peluru menghilang
    public float fireRate = 0.3f;       // jeda antar peluru (detik)

    private float fireTimer = 0f;       // penghitung waktu antar tembakan

    void Update()
    {
        // Kurangi timer tiap frame
        fireTimer -= Time.deltaTime;

        // Jika timer sudah habis, tembak peluru baru
        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate; // reset timer
        }
    }

    void Shoot()
    {
        // Buat peluru
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Tambahkan kecepatan peluru
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed;
        }

        // Hapus peluru setelah waktu tertentu
        Destroy(bullet, bulletLifetime);
    }
}
