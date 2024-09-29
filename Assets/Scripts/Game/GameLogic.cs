using System.Collections.Generic;
using TriangleNet;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private GameObject _player;
    private List<GameObject> _enemies;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemies = new List<GameObject>();
        PersistentDataManager.EnemyDestroyed = 0;
        PersistentDataManager.Level = 0;
    }

    void Update()
    {
        var allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var e in allEnemies)
        {
            if (!_enemies.Contains(e))
            {
                Debug.Log("Add OnEnemyCollided");
                e.GetComponent<BoidController>().Collided += OnEnemyCollided;
                _enemies.Add(e);
            }
        }
    }
    
    private void OnEnemyCollided(object sender, BoidController.CollidedEventArgs e)
    {
        PersistentDataManager.EnemyDestroyed += 1;
        Debug.Log("GameLogic: Amount enemies destroyed: " + PersistentDataManager.EnemyDestroyed);
    }
}
