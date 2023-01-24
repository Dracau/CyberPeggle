using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DefeatScreen : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;

    private Button replayButton, quitButton;

    private void Awake()
    {
        replayButton = uiDocument.rootVisualElement.Q<Button>("replayButton");
        replayButton.clicked += Replay;
        
        quitButton = uiDocument.rootVisualElement.Q<Button>("quitButton");
        quitButton.clicked += Quit;
    }

    private void Quit()
    {
        SceneManager.LoadScene("LevelSelectionMenu");
    }

    private void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
