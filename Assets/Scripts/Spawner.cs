using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    [SerializeField] private float spawnEnemyInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds delay = new WaitForSeconds(spawnEnemyInterval);

        while (enabled)
        {
            SpawnEnemy();

            yield return delay;
        }
    }

    private void SpawnEnemy()
    {
        SpawnPoint spawnPoint = GetRandomSpawnPoint();

        if (spawnPoint != null && spawnPoint.EnemyPrefab != null)
        {
            EnemyMover newEnemy = Instantiate
                (
                spawnPoint.EnemyPrefab,
                spawnPoint.transform.position,
                Quaternion.identity
                );

            newEnemy.SetTarget(spawnPoint.Target);
        }
    }
    
    private SpawnPoint GetRandomSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }

    private Quaternion GetRandomRotation()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized;
        randomDirection.y = 0;

        return Quaternion.LookRotation(randomDirection);
    }
}