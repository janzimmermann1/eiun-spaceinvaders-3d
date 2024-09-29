
using System;
using UnityEngine;

public class PersistentDataManager
{
    private const string EnemyDestroyedKey = "EnemyDestroyed";
    private const string LevelKey = "Level";

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
            OnDataChanged();
        }
    }
    
    public static int Level
    {
        get => PlayerPrefs.GetInt(LevelKey, 1);
        set {
            PlayerPrefs.SetInt(LevelKey, value);
            OnDataChanged();
        }
    }
}