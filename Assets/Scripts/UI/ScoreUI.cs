using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private GameLogic _gameLogic;

    private int _score = 0;
    private int _highScore = 0;

    private void Start()
    {
        _gameLogic = FindObjectOfType<GameLogic>();
        _gameLogic.EnemyDestroyed += (sender, args) =>
        {
            _score = PersistentDataManager.EnemyDestroyed;
            _highScore = PersistentDataManager.EnemiesDestroyedHighScore;
        };
        _score = 0;
        _highScore = PersistentDataManager.EnemiesDestroyedHighScore;
        useGUILayout = true;
    }

    private void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();

        myStyle.fontSize = 48;
        myStyle.font = (Font)Resources.Load("ThaleahFat_TTF");
        myStyle.normal.textColor = Color.white;
        
        GUILayout.BeginArea(new Rect(10, 10, 500, 300));
        GUILayout.Label("Current Score: " + _score, myStyle);
        GUILayout.Label("Highscore: " + _highScore, myStyle);
        GUILayout.EndArea();
    }
}