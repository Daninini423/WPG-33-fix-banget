using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth;

    private bool isDead = false; // Tambahan supaya PlayerDied() tidak dipanggil dua kali
    private void Awake()
    {
        currentHealth = startingHealth;
       
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            GameOverManager.Instance.PlayerDied();  // kasih tahu GameOverManager

            Destroy(gameObject);
        }
        else
        {
            
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
        if (currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);  // Hancurkan peluru setelah kena musuh

            TakeDamage(1);  // Hancurkan peluru setelah kena musuh
        }
    }


}
