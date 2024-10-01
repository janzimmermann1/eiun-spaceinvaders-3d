using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 5f;
    public float startDelay = 2f;
    public float positionVariance = 1f;


    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(startDelay);
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-positionVariance, positionVariance),
            Random.Range(-positionVariance, positionVariance),
            Random.Range(-positionVariance, positionVariance)
        );
        Instantiate(enemyPrefab, randomPosition, transform.rotation);
    }
}
