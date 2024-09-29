using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MainMenuUILogic : MonoBehaviour
{
    private const string StartEasyLevelButtonName = "start-easy-button";
    private const string StartHardLevelButtonName = "start-hard-button";
    private const string GenerateTerrainButtonName = "new-terrain-button";
    private const string QuitButtonName = "quit-button";
    private UIDocument _mainMenuUIDocument;

    public event EventHandler NewTerrainButtonPressed;

    protected virtual void OnNewTerrainButtonPressed()
    {
        NewTerrainButtonPressed?.Invoke(this, EventArgs.Empty);
    }

    private void OnEnable()
    {
        _mainMenuUIDocument = GetComponent<UIDocument>();
        if (_mainMenuUIDocument == null)
        {
            Debug.LogError("Main Menu UI Document is not found");
            enabled = false;
            return;
        }
        
        _mainMenuUIDocument.rootVisualElement.Q<Button>(StartEasyLevelButtonName).clicked += () =>
        {
            Debug.Log("Start easy Button Pressed");
            int sceneNr = 1;
            SceneManager.LoadScene(sceneNr);
        };

        _mainMenuUIDocument.rootVisualElement.Q<Button>(StartHardLevelButtonName).clicked += () =>
        {
            Debug.Log("Start hard Button Pressed");
            int sceneNr = 2;
            SceneManager.LoadScene(sceneNr);
        };

        _mainMenuUIDocument.rootVisualElement.Q<Button>(GenerateTerrainButtonName).clicked += () =>
        {
            Debug.Log("New Terrain Button has been Pressed!");
            var terrainObject = GameObject.FindGameObjectWithTag("Terrain");
            var script = terrainObject.GetComponent<LowPolyGenerator>();
            script.seed = Random.Range(0, 100);
            script.Initiate();
            OnNewTerrainButtonPressed();
        };
        _mainMenuUIDocument.rootVisualElement.Q<Button>(QuitButtonName).clicked += () =>
        {
            #if !UNITY_EDITOR
                Application.Quit();
            #elif UNITY_EDITOR
                EditorApplication.isPlaying = false;
            #endif
        };
    }
}