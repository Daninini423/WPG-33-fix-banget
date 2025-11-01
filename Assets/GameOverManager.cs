using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;  // Singleton sederhana

    [Header("Panel Game Over")]
    public GameObject gameOverPanel;

    private int totalPlayers;    // Jumlah total player di scene
    private int deadPlayers;     // Jumlah player yang sudah mati

    private void Awake()
    {
        Instance = this;
        // Hitung berapa player yang ada di scene (bisa pakai tag "Player")
        totalPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        deadPlayers = 0;
    }

    public void PlayerDied()
    {
        deadPlayers++;

        // Kalau semua player sudah mati
        if (deadPlayers >= totalPlayers)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f; // pause game
        gameOverPanel.SetActive(true);
    }
}
