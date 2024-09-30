using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUIManager : MonoBehaviour
{
    [SerializeField]
    private PauseMenuUILogic _pauseMenuUILogic;
    private PauseMenuUILogic _pauseMenuPanel;
    private ShipController _playerShipController;
    
    private void Awake()
    {
        _pauseMenuPanel = Instantiate(_pauseMenuUILogic, transform);
        _playerShipController = FindObjectOfType<ShipController>();
    }
    
    private void Start()
    {
        _pauseMenuPanel.gameObject.SetActive(false);
        _playerShipController.MenuTriggered += (sender, args) =>
        {
            if (args.IsOpen)
            {
                _pauseMenuPanel.gameObject.SetActive(true);
            }
            else
            {
                _pauseMenuPanel.gameObject.SetActive(false);
            }
        };
        
        _playerShipController.Collided += (sender, args) =>
        {
            if (args.IsCollided)
            {
                StartCoroutine(DelayedSceneLoad(4f));
            }
        };
    }
    
    private IEnumerator DelayedSceneLoad(float delay)
    {
        yield return new WaitForSeconds(delay);
        int sceneNr = 0;
        SceneManager.LoadScene(sceneNr);
    }
}
