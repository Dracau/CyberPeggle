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

        //Story Button
        for(int i = 0; i < buttonsRoot.hierarchy.childCount; i++)
        {

            Button chipButton = (Button)buttonsRoot.hierarchy.ElementAt(i).ElementAt(1);

            Debug.Log($"Added chip n° {i} : {chipButton}");

            int chipIndex = i;
            chipButton.clicked += () => OnChipButtonClicked(chipIndex);
        }

        storyTextField = document.rootVisualElement.Q<Label>("StoryField");
        storyBlock = document.rootVisualElement.Query<VisualElement>("StoryBlockParent");

        Button storyBackButton = document.rootVisualElement.Query<Button>("StoryBackButton");
        storyBackButton.clicked += () => HideStoryBlock();
    }

    private VisualElement storyBlock;
    private Label storyTextField;

    private void OnChipButtonClicked(int i)
    {
        print("Je passe ici");

        if (GameManager.Instance.Collectibles[i])
        {
            if (GameManager.Instance.resolution == 1) storyTextField.style.fontSize = 8;
            storyTextField.text = GameManager.Instance.storyLine[i];


            storyBlock.visible = true;
        }
    }

    private void HideStoryBlock()
    {
        storyBlock.visible = false;
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
