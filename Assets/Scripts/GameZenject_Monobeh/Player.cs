using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnEnemyTouched;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TestEnemy enemy))
        {
            OnEnemyTouched?.Invoke();
        }
    }
}