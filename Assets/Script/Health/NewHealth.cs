/*using UnityEngine;

public class NewHealth : MonoBehaviour
{
    public CameraShake playerCameraShake;
    public Enemy enemy;

    [SerializeField] private float startingHealth;
    public float currentHealth;

    private bool isDead = false; // Supaya PlayerDied() tidak dipanggil dua kali

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        //  Camera Shake saat player kena hit
        if (playerCameraShake != null)
            playerCameraShake.Shake(0.3f, 0.2f);


        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            GameOverManager.Instance.PlayerDied();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Hancurkan musuh yang menabrak
            TakeDamage(1); // Player kehilangan health
        }
    }
}*/

// iki modifikasi ku dan
using UnityEngine;

public class NewHealth : MonoBehaviour
{
    public CameraShake playerCameraShake;
    [SerializeField] private float startingHealth;
    public float currentHealth;

    private bool isDead = false; // Supaya PlayerDied() tidak dipanggil dua kali

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        // Efek camera shake saat player kena hit
        if (playerCameraShake != null)
            playerCameraShake.Shake(0.3f, 0.2f);

        // Jika HP player habis
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            GameOverManager.Instance.PlayerDied();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Ambil script Enemy pada musuh
            Enemy enemyScript = other.GetComponent<Enemy>();
            if (enemyScript != null && enemyScript.spawner != null)
            {
                // Laporkan ke spawner bahwa enemy sudah mati
                enemyScript.spawner.OnEnemyKilled();
            }

            // Hancurkan musuh yang menabrak player
            Destroy(other.gameObject);

            // Kurangi health player
            TakeDamage(1);
        }
    }
}
