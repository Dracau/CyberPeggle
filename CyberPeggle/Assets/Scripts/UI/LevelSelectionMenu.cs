using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LevelSelectionMenu : MonoBehaviour
{
    [SerializeField] private UIDocument document = null;
    
    private void Awake()
    {
        // Quit button
        Button quitButton = document.rootVisualElement.Q<Button>("QuitButton");
        quitButton.clicked += OnQuitButtonClicked;
        
        // Level buttons
        VisualElement buttonsRoot = document.rootVisualElement.Q<VisualElement>("ButtonsRoot");
        for (int i = 0; i < buttonsRoot.hierarchy.childCount; i++)
        {
            Button levelButton = (Button)buttonsRoot.hierarchy.ElementAt(i).ElementAt(0);
            int levelIndex = i + 1;
            levelButton.clicked += () => OnLevelButtonClicked(levelIndex);
        }
        quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnLevelButtonClicked(int levelIndex)
    {
        // Load level
        GameManager.Instance.LevelIndex = levelIndex;
        SceneManager.LoadScene("Levels");
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
