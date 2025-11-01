using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; // Kecepatan pergerakan
    private Rigidbody2D body; // Referensi Rigidbody2D

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); // Mendapatkan komponen Rigidbody2D
    }

    private void Update()
    {
        // Mendapatkan input dari tombol WASD
        float speedX = 0f; // Kecepatan horizontal
        float speedY = 0f; // Kecepatan vertikal

        // Cek tombol W (naik)
        if (Input.GetKey(KeyCode.W))
        {
            speedY = speed; // Gerak ke atas
        }
        // Cek tombol S (turun)
        else if (Input.GetKey(KeyCode.S))
        {
            speedY = -speed; // Gerak ke bawah
        }

        // Cek tombol A (kiri)
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -speed; // Gerak ke kiri
        }
        // Cek tombol D (kanan)
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = speed; // Gerak ke kanan
        }

        // Mengatur kecepatan Rigidbody2D
        body.velocity = new Vector2(speedX, speedY);

        // Mengubah skala karakter berdasarkan arah gerakan
  
        if (speedX > 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);  // kanan
        else if (speedX < -0.01f)
            transform.localScale = new Vector3(1, 1, 1);   // kiri


    }
}
