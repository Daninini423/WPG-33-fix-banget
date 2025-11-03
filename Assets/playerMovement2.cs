using UnityEngine;

public class playerMovement2 : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Kecepatan pergerakan
    private Rigidbody2D body;
    private Vector2 moveInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ambil input dari tombol panah
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
            moveX = 1f;
        else if (Input.GetKey(KeyCode.LeftArrow))
            moveX = -1f;

        if (Input.GetKey(KeyCode.UpArrow))
            moveY = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            moveY = -1f;

        moveInput = new Vector2(moveX, moveY).normalized;

        // Hadapkan karakter sesuai arah
        if (moveX > 0.01f)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else if (moveX < -0.01f)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void FixedUpdate()
    {
        // Gerakkan karakter berdasarkan input
        body.velocity = moveInput * speed;
    }
}
