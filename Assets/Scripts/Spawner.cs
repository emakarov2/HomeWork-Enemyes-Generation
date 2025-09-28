using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
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
            SpawnNewEnemy();

            yield return delay;
        }
    }

    private void SpawnNewEnemy()
    {
        Transform spawnPoint = GetRandomSpawnPoint();
        Quaternion spawnRotation = GetRandomRotation();
        Vector3 moveDirection = spawnRotation * Vector3.forward;
                      
        EnemyMover enemyMover = Instantiate(_enemyPrefab, spawnPoint.position, spawnRotation).AddComponent<EnemyMover>();
        enemyMover.Initialize(moveDirection);
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