using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class LevelResultWindow : WindowBase
{
    public event UnityAction loadMainMenuButtonClicked;

    [SerializeField] private Button loadMainMenuButton;

    private void Start()
    {
        loadMainMenuButton.onClick.AddListener(() => loadMainMenuButtonClicked?.Invoke());
    }
}