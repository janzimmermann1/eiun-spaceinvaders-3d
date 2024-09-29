using System;
using UnityEngine;

public class HomeUIManager : MonoBehaviour
{
    [SerializeField] private MainMenuUILogic mainMenuPanelPrefab;
    private MainMenuUILogic _mainMenuPanel;

    private void Awake()
    {
        _mainMenuPanel = Instantiate(mainMenuPanelPrefab, transform);
    }

    private void Start()
    {
        _mainMenuPanel.NewTerrainButtonPressed += OnNewTerrainButtonPressed;
    }

    private void OnNewTerrainButtonPressed(object sender, EventArgs e)
    {
        Debug.Log($"OnNewTerrainButtonPressed: {sender}");
    }
}
