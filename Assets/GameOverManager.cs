/*using UnityEngine;
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
}*/

// iki modifikasi ku dan
using UnityEngine;
using TMPro; // pakai TextMeshPro

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;  // Singleton sederhana

    [Header("Panel Game Over")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;       // Teks untuk skor akhir
    public TextMeshProUGUI highScoreText;   // Teks untuk high score
    public GameObject newHighScoreText;     // (Opsional) teks “New High Score!”

    private int totalPlayers;    // Jumlah total player di scene
    private int deadPlayers;     // Jumlah player yang sudah mati

    private int currentScore;
    private int highScore;

    private void Awake()
    {
        Instance = this;
        totalPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        deadPlayers = 0;

        // Ambil high score tersimpan
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Sembunyikan panel dan teks high score di awal
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (newHighScoreText != null)
            newHighScoreText.SetActive(false);
    }

    public void PlayerDied()
    {
        deadPlayers++;

        // Kalau semua player sudah mati → game over
        if (deadPlayers >= totalPlayers)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);

        // Ambil skor akhir dari ScoreManager
        ScoreManager scoreManager = ScoreManager.instance;

        if (scoreManager != null)
        {
            currentScore = scoreManager.GetCurrentScore();
            scoreManager.SaveHighScore(); // simpan high score baru
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Tampilkan skor akhir
        if (scoreText != null)
            scoreText.text = "Score: " + currentScore;

        // Cek dan update high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            if (newHighScoreText != null)
                newHighScoreText.SetActive(true);
        }

        // Tampilkan teks high score
        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore;
    }

    // Fungsi tombol "Try Again"
    public void Retry()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}

