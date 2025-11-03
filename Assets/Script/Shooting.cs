using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;     // posisi tembakan
    public GameObject bulletPrefab; // prefab peluru
    public float bulletSpeed = 10f; // kecepatan peluru
    public float bulletLifetime = 3f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // gerakkan peluru ke arah kanan firePoint
            rb.velocity = firePoint.right * bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }
}
