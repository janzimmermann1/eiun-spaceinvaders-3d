using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class PauseMenuUILogic : MonoBehaviour
{
    private const string ResumeButtonName = "resume-button";
    private const string GenerateTerrainButtonName = "new-terrain-button";
    private const string MainMenuButtonName = "main-menu-button";
    private UIDocument _pauseMenuUIDocument;
    
    private float _timeScale;

    private void OnDisable()
    {
        Debug.Log("PauseMenuUILogic: disable Pause Menu");
        Time.timeScale = _timeScale;
    }

    private void OnEnable()
    {
        Debug.Log("PauseMenuUILogic: enable Pause Menu");
        _timeScale = Time.timeScale;
        Time.timeScale = 0;
        _pauseMenuUIDocument = GetComponent<UIDocument>();
        if (_pauseMenuUIDocument == null)
        {
            Debug.LogError("PauseMenuUILogic: Pause Menu UI Document is not found");
            enabled = false;
            return;
        }

        _pauseMenuUIDocument.rootVisualElement.Q<Button>(ResumeButtonName).clicked += () =>
        {
            Debug.Log("PauseMenuUILogic: Resume Button Pressed");
            gameObject.SetActive(false);
        };

        _pauseMenuUIDocument.rootVisualElement.Q<Button>(GenerateTerrainButtonName).clicked += () =>
        {
            Debug.Log("PauseMenuUILogic: New Terrain Button has been Pressed!");
            var terrainObject = GameObject.FindGameObjectWithTag("Terrain");
            var script = terrainObject.GetComponent<LowPolyGenerator>();
            script.seed = Random.Range(0, 100);
            script.Initiate();
        };
        _pauseMenuUIDocument.rootVisualElement.Q<Button>(MainMenuButtonName).clicked += () =>
        {
            Debug.Log("PauseMenuUILogic: Main Menu Button Pressed");
            int sceneNr = 0;
            SceneManager.LoadScene(sceneNr);
        };
    }
}