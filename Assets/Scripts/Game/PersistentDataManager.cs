
using System;
using UnityEngine;

public class PersistentDataManager
{
    private const string EnemyDestroyedKey = "EnemyDestroyed";
    private const string EnemiesDestroyedHighScoreKey = "EnemiesDestroyedHighScore";

    public static event EventHandler DataChangedEvent;

    private static void OnDataChanged()
    {
        DataChangedEvent?.Invoke(null, EventArgs.Empty);
    }

    public static int EnemyDestroyed
    {
        get => PlayerPrefs.GetInt(EnemyDestroyedKey, 0);
        set {
            PlayerPrefs.SetInt(EnemyDestroyedKey, value);
            if (value > EnemiesDestroyedHighScore)
            {
                EnemiesDestroyedHighScore = value;
            }
            OnDataChanged();
        }
    }
    
    public static int EnemiesDestroyedHighScore
    {
        get => PlayerPrefs.GetInt(EnemiesDestroyedHighScoreKey, 0);
        set {
            PlayerPrefs.SetInt(EnemiesDestroyedHighScoreKey, value);
            OnDataChanged();
        }
    }
}