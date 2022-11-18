using System;
using UnityEngine;

public class Input : MonoBehaviour
{
    public event Action<Vector3> MouseClicked;

    private void OnEnable()
    {
        MouseClicked?.Invoke(Vector3.zero);
    }
}