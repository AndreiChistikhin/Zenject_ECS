using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private Transform _playerTest;

    [Inject]
    private void Construct(PlayerTest playerTest)
    {
        _playerTest = playerTest.transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_playerTest.position, 1);
        Gizmos.color = Color.white;
    }
}