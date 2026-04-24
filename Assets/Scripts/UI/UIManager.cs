using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI mobCountText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Canvas settingsPanel;
    [SerializeField] private Canvas gameOverPanel;

    private void Start()
    {
        if (pauseButton != null)
            pauseButton.onClick.AddListener(PauseGame);
        
        if (settingsButton != null)
            settingsButton.onClick.AddListener(OpenSettings);
        
        if (gameOverPanel != null)
            gameOverPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        UpdateUI();
        
        if (GameManager.Instance.IsGameOver() && gameOverPanel != null)
        {
            gameOverPanel.gameObject.SetActive(true);
        }
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {GameManager.Instance.GetCurrentScore()}";

        if (highScoreText != null)
            highScoreText.text = $"High Score: {GameManager.Instance.GetHighScore()}";

        if (levelText != null)
            levelText.text = $"Level: {GameManager.Instance.GetCurrentLevel()}";

        MobController mobController = FindObjectOfType<MobController>();
        if (mobCountText != null && mobController != null)
            mobCountText.text = $"Mobs: {mobController.GetMobCount()}";

        Character character = FindObjectOfType<Character>();
        if (healthText != null && character != null)
            healthText.text = $"Health: {character.GetHealth()}";
    }

    public void PauseGame()
    {
        GameManager.Instance.TogglePause();
        Debug.Log("Game paused");
    }

    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.gameObject.SetActive(true);
        }
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.gameObject.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        GameManager.Instance.RestartLevel();
    }

    public void LoadMainMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
