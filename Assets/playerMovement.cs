using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Kecepatan gerak
    private Rigidbody2D body;
    private Vector2 moveInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ambil input dari pemain tiap frame
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        else if (Input.GetKey(KeyCode.S)) moveY = -1f;

        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        else if (Input.GetKey(KeyCode.A)) moveX = -1f;

        moveInput = new Vector2(moveX, moveY).normalized; // Normalisasi biar kecepatan diagonal tetap konsisten

        // Ganti arah karakter sesuai arah gerak
        if (moveX > 0.01f)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (moveX < -0.01f)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void FixedUpdate()
    {
        // Jalankan pergerakan di sistem fisika
        body.velocity = moveInput * speed;
    }
}
