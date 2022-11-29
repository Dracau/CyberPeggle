using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private GameObject menu;
    public bool paused;

    private void Awake()
    {
        instance = this;
    }

    public void ReadPauseInput(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        TogglePause();
    }
    public void TogglePause()
    {
        paused = !paused;
        menu.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }
    
}
