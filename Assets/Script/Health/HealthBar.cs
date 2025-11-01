using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Tambahkan ini untuk menggunakan Image

public class HealthBar : MonoBehaviour
{
    [SerializeField] private NewHealth playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;

    private void Start()
    {
        // Cast currentHealth atau gunakan 10f untuk menghindari integer division
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10f;
    }

    private void Update()
    {
        // Cast currentHealth atau gunakan 10f untuk menghindari integer division
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10f;
    }
}
