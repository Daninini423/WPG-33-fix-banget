using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public Transform firePoint; // Titik tempat peluru ditembakkan
    public GameObject bulletPrefab; // Prefab peluru

    public float bulletForce = 20f; // Kekuatan peluru
    public float bulletLifetime = 2f; // Waktu sebelum peluru dihancurkan

    void Update()
    {
        // Tembak menggunakan tombol A
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Membuat peluru di posisi firePoint dengan rotasi yang sama dengan firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Mendapatkan komponen Rigidbody2D dari peluru
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Menambahkan gaya pada peluru agar bergerak sesuai arah firePoint
        rb.AddForce(firePoint.right* bulletForce, ForceMode2D.Impulse);

        // Hancurkan peluru setelah waktu tertentu (misalnya 2 detik)
        Destroy(bullet, bulletLifetime);
    }
}
