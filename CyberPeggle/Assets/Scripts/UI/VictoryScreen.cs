using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;

    private Button replayButton, quitButton, nextLevelButton;

    private void Awake()
    {
        replayButton = uiDocument.rootVisualElement.Q<Button>("replayButton");
        replayButton.clicked += Replay;
        
        quitButton = uiDocument.rootVisualElement.Q<Button>("quitButton");
        quitButton.clicked += Quit;
        
        nextLevelButton = uiDocument.rootVisualElement.Q<Button>("nextLevelButton");
        nextLevelButton.clicked += NextLevel;
    }

    private void NextLevel()
    {
        GameManager.Instance.LevelIndex++;
        Replay();
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
