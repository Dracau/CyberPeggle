using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [field : SerializeField] public LevelData_SO LevelData { get; private set; } = null;
    [field : SerializeField] public Canon Canon { get; private set; } = null;
    [field : SerializeField] public PlayerMarble Player { get; private set; } = null;

    private void Awake()
    {
        PickableMarble.PickableMarbles = new List<PickableMarble>();
        Time.timeScale = 1;
    }

    private void Start()
    {
        GameManager.Instance.LevelManager = this;
        Canon.Initialize();
        Player.Initialize();
    }
}
