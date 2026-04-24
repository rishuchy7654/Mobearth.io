using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Toggle tapToggle;
    [SerializeField] private Toggle swipeToggle;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button closeButton;
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        if (tapToggle != null)
            tapToggle.onValueChanged.AddListener(OnTapSelected);
        
        if (swipeToggle != null)
            swipeToggle.onValueChanged.AddListener(OnSwipeSelected);
        
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        
        if (closeButton != null)
            closeButton.onClick.AddListener(CloseSettings);
        
        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(GoToMainMenu);

        // Load current settings
        if (InputManager.Instance != null)
        {
            ControlMode currentMode = InputManager.Instance.GetControlMode();
            if (tapToggle != null)
                tapToggle.isOn = currentMode == ControlMode.Tap;
            if (swipeToggle != null)
                swipeToggle.isOn = currentMode == ControlMode.Swipe;
        }
        
        if (volumeSlider != null)
            volumeSlider.value = AudioListener.volume;
    }

    private void OnTapSelected(bool isSelected)
    {
        if (isSelected && InputManager.Instance != null)
        {
            InputManager.Instance.SetControlMode(ControlMode.Tap);
            if (swipeToggle != null)
                swipeToggle.isOn = false;
        }
    }

    private void OnSwipeSelected(bool isSelected)
    {
        if (isSelected && InputManager.Instance != null)
        {
            InputManager.Instance.SetControlMode(ControlMode.Swipe);
            if (tapToggle != null)
                tapToggle.isOn = false;
        }
    }

    private void OnVolumeChanged(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    private void CloseSettings()
    {
        gameObject.SetActive(false);
    }

    private void GoToMainMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}
