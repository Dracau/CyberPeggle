using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [field : SerializeField] public LevelData_SO LevelData { get; private set; } = null;
    [field : SerializeField] public Canon Canon { get; private set; } = null;
    [field : SerializeField] public PlayerMarble Player { get; private set; } = null;
    [field: SerializeField] public CameraShake CameraShake { get; private set; } = null;
    [SerializeField] private Transform levelsParent;

    private void Awake()
    {
        if (levelsParent != null)
        {
            for (int i = 0; i < levelsParent.childCount; i++)
            {
                levelsParent.GetChild(i).gameObject.SetActive(false);
            }
        }

        PickableMarble.PickableMarbles = new List<PickableMarble>();
        Time.timeScale = 1;
    }

    private void Start()
    {
        GameManager.Instance.LevelManager = this;
        Player.Initialize();
        LoadLevel(GameManager.Instance.LevelIndex);
    }

    private void LoadLevel(int index)
    {
        if (levelsParent == null || levelsParent.childCount < index) return;
        levelsParent.GetChild(index - 1).gameObject.SetActive(true);
    }
}
