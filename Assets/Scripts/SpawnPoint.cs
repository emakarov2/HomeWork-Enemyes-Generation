using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _enemyPrefab;

    public Transform Target => _target;
    public Transform EnemyPrefab => _enemyPrefab;
}
