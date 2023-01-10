using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private UIDocument uiDocument;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeSourceAsset(VisualTreeAsset asset)
    {
        uiDocument.visualTreeAsset = asset;
    }
}
