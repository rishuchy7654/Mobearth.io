using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int highScore = 0;
    [SerializeField] private bool isGameOver = false;
    [SerializeField] private bool isPaused = false;
    [SerializeField] private int mobsDefeated = 0;

    private int levelStartScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    private void Start()
    {
        levelStartScore = currentScore;
        Time.timeScale = 1f;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        Debug.Log($"Score: {currentScore}");
        
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
    }

    public void OnEnemyDefeated()
    {
        mobsDefeated++;
        AddScore(100);
    }

    public void LevelComplete()
    {
        Debug.Log($"Level {currentLevel} completed!");
        int levelBonus = 500;
        AddScore(levelBonus);
        
        SaveHighScore();
        
        // Show ads between levels
        StartCoroutine(LoadNextLevelWithAd());
    }

    private IEnumerator LoadNextLevelWithAd()
    {
        yield return new WaitForSeconds(2f);
        
        // Show interstitial ad
        if (AdsManager.Instance != null)
        {
            AdsManager.Instance.ShowInterstitialAd();
        }
        
        yield return new WaitForSeconds(1f);
        
        // Load next level
        currentLevel++;
        if (currentLevel > 10)
        {
            currentLevel = 10; // Max 10 levels
        }
        
        LoadLevel(currentLevel);
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f; // Pause game
        Debug.Log("Game Over!");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        currentScore = levelStartScore;
        mobsDefeated = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLevel(int levelNumber)
    {
        Time.timeScale = 1f;
        isGameOver = false;
        mobsDefeated = 0;
        SceneManager.LoadScene($"Level_{levelNumber}");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        currentLevel = 1;
        currentScore = 0;
        mobsDefeated = 0;
        SceneManager.LoadScene("MainMenu");
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("LastLevel", currentLevel);
        PlayerPrefs.Save();
    }

    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        currentLevel = PlayerPrefs.GetInt("LastLevel", 1);
    }

    // Getters
    public int GetCurrentLevel() => currentLevel;
    public int GetCurrentScore() => currentScore;
    public int GetHighScore() => highScore;
    public bool IsGameOver() => isGameOver;
    public bool IsPaused() => isPaused;
    public int GetMobsDefeated() => mobsDefeated;
}
