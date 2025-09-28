using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed = 3f;
    private Vector3 _moveDirection;

    public void Initialize(Vector3 direction)
    {
        _moveDirection = direction.normalized;

        if (_moveDirection != Vector3.zero) 
        { 
        transform.rotation = Quaternion.LookRotation(_moveDirection);
        }
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime, Space.World);
    }
}