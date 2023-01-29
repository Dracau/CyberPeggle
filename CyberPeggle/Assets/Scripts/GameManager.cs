using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    [HideInInspector] public LevelManager LevelManager = null;
    public int LevelIndex = 1;
    public bool[] Collectibles = new bool[3];

    public int resolution = 1;

    [TextArea]
    public string[] storyLine = new string[3];
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Victory()
    {
        MenuManager.instance.OpenVictoryScreen();
    }

    public void Defeat()
    {
        MenuManager.instance.OpenDefeatScreen();
    }
}
