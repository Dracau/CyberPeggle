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
        MenuManager.instance.VictoryPanel.SetActive(true);
        StartCoroutine(ReloadScene());
    }

    public void Defeat()
    {
        MenuManager.instance.DefeatPanel.SetActive(true);
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
