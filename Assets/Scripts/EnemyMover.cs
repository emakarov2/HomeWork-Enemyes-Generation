using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 5f;

    private void Update()
    {
        MoveToTarget();
        RotateToTarget();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void RotateToTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }
}