using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private UIDocument uiDocument;
    //[SerializeField] private GameObject menu;
    public bool paused;

    private Button resumeButton, quitButton;
    private VisualElement volumeSlider;

    private void Awake()
    {
        instance = this;
        resumeButton = uiDocument.rootVisualElement.Q<Button>("ResumeButton");
        quitButton = uiDocument.rootVisualElement.Q<Button>("QuitButton");
        volumeSlider = uiDocument.rootVisualElement.Q<Slider>("VolumeSlider");
        
        resumeButton.clicked += TogglePause;
        quitButton.clicked += Quit;
        volumeSlider.RegisterCallback<ChangeEvent<float>>(UpdateVolume);
        
        uiDocument.rootVisualElement.style.display = DisplayStyle.None;
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
        uiDocument.rootVisualElement.style.display = paused ? DisplayStyle.Flex : DisplayStyle.None;
    }

    public void UpdateVolume(ChangeEvent<float> evt)
    {
        AudioListener.volume = evt.newValue;
        Debug.Log("Volume: " + evt.newValue);
    }

    public void Quit()
    {
        Debug.Log(1);
        // A remplacer par le retour à la world map
        Application.Quit();
    }
}
