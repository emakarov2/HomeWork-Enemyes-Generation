using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private EnemyMover _enemyPrefab;

    public Transform Target => _target;
    public EnemyMover EnemyPrefab => _enemyPrefab;
}