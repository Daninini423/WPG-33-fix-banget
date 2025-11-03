/*using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton
    public TMP_Text scoreText;            // TextMeshPro untuk menampilkan score
    private int score = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}*/

// iki modifikasi ku dan
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton
    [Header("UI")]
    public TMP_Text scoreText;            // TextMeshPro untuk menampilkan skor di HUD

    private int score = 0;                // skor berjalan
    private int highScore = 0;            // high score tersimpan

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // Ambil high score dari PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    /// <summary>
    /// Tambah skor pemain
    /// </summary>
    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    /// <summary>
    /// Dapatkan skor saat ini
    /// </summary>
    public int GetCurrentScore()
    {
        return score;
    }

    /// <summary>
    /// Dapatkan high score
    /// </summary>
    public int GetHighScore()
    {
        return highScore;
    }

    /// <summary>
    /// Update tampilan teks skor di UI
    /// </summary>
    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Simpan high score (dipanggil saat GameOver)
    /// </summary>
    public void SaveHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            Debug.Log($"New High Score: {highScore}");
        }
    }
}
