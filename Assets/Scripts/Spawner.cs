using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

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
        Transform spawnPoint = GetRandomSpawnPoint();

        if (spawnPoint.TryGetComponent<SpawnPoint>(out SpawnPoint spawnPointComponent))
        {
            if (spawnPointComponent.EnemyPrefab != null)
            {
                Transform newEnemy = Instantiate(spawnPointComponent.EnemyPrefab, spawnPoint.position, Quaternion.identity);

                newEnemy.TryGetComponent<EnemyMover>(out EnemyMover component);
                {
                    component.SetTarget(spawnPointComponent.Target);
                }
            }
        }
    }

    private Transform GetRandomSpawnPoint()
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