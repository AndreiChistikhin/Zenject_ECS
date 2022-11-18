using UnityEngine;
using Zenject;

public class TestEnemy : MonoBehaviour
{
    private readonly int _speed = 10;
    private readonly int _maxAliveTime = 5;
    private Transform _playerTransform;
    private float _currentAliveTime;

    public int MaxAliveTime => _maxAliveTime;
    
    [Inject]
    private void Construct(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    private void Update()
    {
        if (_playerTransform == null)
            return;
        Vector3 direction = _playerTransform.position - transform.position;
        transform.position += direction.normalized * Time.deltaTime * _speed;
        _currentAliveTime += Time.deltaTime;
        if(_currentAliveTime>=_maxAliveTime)
            Destroy(gameObject);
    }
}