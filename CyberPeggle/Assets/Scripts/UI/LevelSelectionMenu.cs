using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
            Button levelButton = (Button)buttonsRoot.hierarchy.ElementAt(i);
            int levelIndex = i + 1;
            levelButton.clicked += () => OnLevelButtonClicked(levelIndex);
        }
        quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnLevelButtonClicked(int levelIndex)
    {
        // Load level
        print("Load level" + levelIndex);
    }

    private void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
