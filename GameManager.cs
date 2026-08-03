using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Central controller for Flappy Bird. Implemented as a Singleton so that
/// PlayerController and Speed scripts can query game state (isGameOver)
/// and trigger score/game-over events without direct references.
/// Handles obstacle spawning, UI panel transitions, live score tracking,
/// and a persistent top-5 leaderboard stored via PlayerPrefs.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Obstacle Spawning")]
    public GameObject obstaclePrefab;
    private float timer = 0f;
    private const float spawnInterval = 2f;

    [Header("Game State")]
    public bool isGameOver = false;
    private int score = 0;

    [Header("UI References")]
    public GameObject startMenuPanel;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI leaderboardText;

    [Header("Leaderboard")]
    private List<int> leaderboard = new List<int>();
    private const int maxEntries = 5;
    private const string KEY_COUNT = "LB_Count";
    private const string KEY_ENTRY = "LB_Entry_";

    private void Awake()
    {
        // Singleton pattern — ensures only one GameManager exists
        instance = this;
        LoadLeaderboard();
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        startMenuPanel.SetActive(true);
        scoreText.gameObject.SetActive(false);
        Time.timeScale = 0f; // Freeze game on Start Menu
    }

    private void Update()
    {
        if (!isGameOver)
        {
            if (timer <= 0f)
            {
                GameObject obs = Instantiate(
                    obstaclePrefab,
                    new Vector3(5f, Random.Range(-7.5f, -4.5f), 0f),
                    Quaternion.identity);
                Destroy(obs, 5f);
                timer = spawnInterval;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Called by the Play button on the Start Menu. Hides the start menu,
    /// reveals the live score text, and unfreezes time to begin gameplay.
    /// </summary>
    public void StartGame()
    {
        startMenuPanel.SetActive(false);
        scoreText.gameObject.SetActive(true);
        score = 0;
        UpdateScoreText();
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Called by PlayerController when the bird passes through a ScoreZone trigger.
    /// </summary>
    public void IncreaseScore()
    {
        if (isGameOver) return;
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

    /// <summary>
    /// Called by PlayerController on collision with an Obstacle or the Ground.
    /// Freezes time, saves the score to the leaderboard, and shows the Game Over panel.
    /// Guarded so multiple simultaneous collisions can't fire this more than once.
    /// </summary>
    public void TriggerGameOver()
    {
        if (isGameOver) return; // Double-call guard

        isGameOver = true;
        Time.timeScale = 0f;

        AddScoreToLeaderboard(score);

        gameOverPanel.SetActive(true);
        if (bestScoreText != null && leaderboard.Count > 0)
            bestScoreText.text = "Best: " + leaderboard[0];

        DisplayLeaderboard();
    }

    private void AddScoreToLeaderboard(int newScore)
    {
        leaderboard.Add(newScore);
        leaderboard.Sort((a, b) => b.CompareTo(a)); // Highest first

        if (leaderboard.Count > maxEntries)
            leaderboard.RemoveRange(maxEntries, leaderboard.Count - maxEntries);

        SaveLeaderboard();
    }

    private void SaveLeaderboard()
    {
        PlayerPrefs.SetInt(KEY_COUNT, leaderboard.Count);
        for (int i = 0; i < leaderboard.Count; i++)
            PlayerPrefs.SetInt(KEY_ENTRY + i, leaderboard[i]);
        PlayerPrefs.Save();
    }

    private void LoadLeaderboard()
    {
        leaderboard.Clear();
        int count = PlayerPrefs.GetInt(KEY_COUNT, 0);
        for (int i = 0; i < count; i++)
            leaderboard.Add(PlayerPrefs.GetInt(KEY_ENTRY + i, 0));
    }

    private void DisplayLeaderboard()
    {
        if (leaderboardText == null) return;

        string[] medals = { "🥇", "🥈", "🥉" };
        string display = "";

        for (int i = 0; i < leaderboard.Count; i++)
        {
            string prefix = i < 3 ? medals[i] : (i + 1) + ".";
            display += $"{prefix}  {leaderboard[i]}\n";
        }

        leaderboardText.text = display;
    }

    /// <summary>
    /// Called by the Exit button on the Start Menu.
    /// </summary>
    public void ExitGame()
    {
        Application.Quit();
    }
}
