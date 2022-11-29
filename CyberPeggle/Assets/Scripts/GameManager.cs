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
        print("victory");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Defeat()
    {
        print("defeat");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
