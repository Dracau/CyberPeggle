using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private UIDocument pauseMenu;
    [HideInInspector] public bool paused;

    [SerializeField] private VictoryScreen victoryScreen = null;
    [SerializeField] private DefeatScreen defeatScreen = null;

    private Button resumeButton, quitButton;
    private VisualElement volumeSlider;

    private void Awake()
    {
        instance = this;
        resumeButton = pauseMenu.rootVisualElement.Q<Button>("ResumeButton");
        quitButton = pauseMenu.rootVisualElement.Q<Button>("QuitButton");
        volumeSlider = pauseMenu.rootVisualElement.Q<Slider>("VolumeSlider");
        
        resumeButton.clicked += TogglePause;
        quitButton.clicked += Quit;
        volumeSlider.RegisterCallback<ChangeEvent<float>>(UpdateVolume);
        
        pauseMenu.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void ReadPauseInput(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        TogglePause();
    }
    private void TogglePause()
    {
        Debug.Log(0);
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        pauseMenu.rootVisualElement.style.display = paused ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public void UpdateVolume(ChangeEvent<float> evt)
    {
        AudioListener.volume = evt.newValue;
        Debug.Log("Volume: " + evt.newValue);
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
