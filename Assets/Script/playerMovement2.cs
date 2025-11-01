using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement2 : MonoBehaviour
{
    [SerializeField] private float speed; // Kecepatan pergerakan
    private Rigidbody2D body; // Referensi Rigidbody2D

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>(); // Mendapatkan komponen Rigidbody2D
    }

    private void Update()
    {
        // Mendapatkan input dari tombol panah
        float speedX = 0f; // Kecepatan horizontal
        float speedY = 0f; // Kecepatan vertikal

        if (Input.GetKey(KeyCode.RightArrow)) // Jika tombol panah kanan ditekan
        {
            speedX = speed; // Gerak ke kanan
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) // Jika tombol panah kiri ditekan
        {
            speedX = -speed; // Gerak ke kiri
        }

        if (Input.GetKey(KeyCode.UpArrow)) // Jika tombol panah atas ditekan
        {
            speedY = speed; // Gerak ke atas
        }
        else if (Input.GetKey(KeyCode.DownArrow)) // Jika tombol panah bawah ditekan
        {
            speedY = -speed; // Gerak ke bawah
        }

        // Mengatur kecepatan Rigidbody2D
        body.velocity = new Vector2(speedX, speedY);

        // Mengubah skala karakter berdasarkan arah gerakan
        if (speedX > 0.01f)
            transform.eulerAngles = new Vector3(0, 0, 0);  // Menghadapkan karakter ke kanan
        else if (speedX < -0.01f)
            transform.eulerAngles = new Vector3(0, 180, 0); // Menghadapkan karakter ke kiri
    }
}
