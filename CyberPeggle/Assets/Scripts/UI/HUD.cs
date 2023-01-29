using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;

    private Label playerLives, marblesTaken, collectibles;
    private int maxMarblesNumber;

    private void Awake()
    {
        playerLives = uiDocument.rootVisualElement.Q<Label>("playerLivesText");
        marblesTaken = uiDocument.rootVisualElement.Q<Label>("marblesTakenText");
        collectibles = uiDocument.rootVisualElement.Q<Label>("collectiblesNumberText");
    }

    public void UpdatePlayerLives(int lives)
    {
        playerLives.text = lives.ToString();
    }

    public void UpdateMarblesTaken(int marblesTakenNumber, int maxMarbles)
    {
        if (maxMarbles == 0)
        {
            marblesTaken.text = (maxMarblesNumber - marblesTakenNumber) + "/" + maxMarblesNumber;
        }
        else
        {
            marblesTaken.text = marblesTakenNumber + "/" + maxMarbles;
            maxMarblesNumber = maxMarbles;
        }
    }

    public void UpdateCollectibles(int collectiblesNumber)
    {
        collectibles.text = collectiblesNumber + "/3";
    }
}
