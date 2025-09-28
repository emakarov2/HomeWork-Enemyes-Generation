using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed = 3f;    

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
