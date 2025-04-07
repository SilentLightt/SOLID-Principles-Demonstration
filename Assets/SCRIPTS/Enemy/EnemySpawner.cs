using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public interface ISpawner
{
    void SpawnEnemies();
}

public class EnemySpawner : MonoBehaviour, ISpawner
{
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int maxEnemies = 5;
    [SerializeField] private float spawnInterval = 2f;

    private Queue<IEnemy> enemyPool = new Queue<IEnemy>();

    private void Start()
    {
        // Initialize the pool of enemies to be reused
        for (int i = 0; i < maxEnemies; i++)
        {
            GameObject enemyObject = Instantiate(enemyPrefab);
            IEnemy enemy = enemyObject.GetComponent<IEnemy>();
            enemyObject.SetActive(false);
            enemyPool.Enqueue(enemy);
        }

        StartCoroutine(SpawnRoutine());
    }

    public void SpawnEnemies()
    {
        if (enemyPool.Count > 0)
        {
            // Pick a spawn point randomly
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            IEnemy enemy = enemyPool.Dequeue();
            enemy.Spawn(spawnPoint.position);
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemies();
        }
    }
}