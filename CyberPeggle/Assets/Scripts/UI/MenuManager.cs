using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private UIDocument pauseMenu;
    [HideInInspector] public bool paused;

    [SerializeField] private VictoryScreen victoryScreen = null;
    [SerializeField] private DefeatScreen defeatScreen = null;

    private Button resumeButton, quitButton;
    private VisualElement volumeSlider;
    private DropdownField resolutionDropdown;

    private void Awake()
    {
        instance = this;
        resumeButton = pauseMenu.rootVisualElement.Q<Button>("ResumeButton");
        quitButton = pauseMenu.rootVisualElement.Q<Button>("QuitButton");
        volumeSlider = pauseMenu.rootVisualElement.Q<Slider>("VolumeSlider");
        resolutionDropdown = pauseMenu.rootVisualElement.Q<DropdownField>("ResolutionDropdown");

        resumeButton.clicked += TogglePause;
        quitButton.clicked += Quit;
        volumeSlider.RegisterCallback<ChangeEvent<float>>(UpdateVolume);
        resolutionDropdown.RegisterValueChangedCallback(ChangeResolution);
        
        pauseMenu.rootVisualElement.style.display = DisplayStyle.None;
    }

    private void ChangeResolution(ChangeEvent<string> evt)
    {
        switch (evt.newValue)
        {
            case "1920x1080":
                Screen.SetResolution(1920, 1080, true);
                break;
            case "1280x720":
                Screen.SetResolution(1280, 720, false);
                break;
            case "854x480":
                Screen.SetResolution(854, 480, false);
                break;
        }
    }

    public void ReadPauseInput(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        TogglePause();
    }
    private void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        pauseMenu.rootVisualElement.style.display = paused ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public void UpdateVolume(ChangeEvent<float> evt)
    {
        AudioListener.volume = evt.newValue;
    }

    public void Quit()
    {
        SceneManager.LoadScene("LevelSelectionMenu");
    }

    public void OpenDefeatScreen()
    {
        Time.timeScale = 0;
        defeatScreen.gameObject.SetActive(true);
    }

    public void OpenVictoryScreen()
    {
        Time.timeScale = 0;
        victoryScreen.gameObject.SetActive(true);
    }
}
