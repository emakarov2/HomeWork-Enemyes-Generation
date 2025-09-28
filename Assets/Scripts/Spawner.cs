using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private float spawnEnemyInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled)
        {
            SpawnNewEnemy();

            yield return new WaitForSeconds(spawnEnemyInterval);
        }
    }

    private void SpawnNewEnemy()
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        Quaternion spawnRotation = GetRandomRotation();

        Instantiate(enemyPrefab, spawnPoint.position, spawnRotation).AddComponent<EnemyMover>();
    }

    private Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }

    private Quaternion GetRandomRotation()
    {
        Vector3 randomDirection = Random.insideUnitSphere.normalized;
        randomDirection.y = 0;
        
        return Quaternion.LookRotation(randomDirection);
    }
}
