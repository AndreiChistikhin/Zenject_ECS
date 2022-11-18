using UnityEngine;

public class EnemyMarker : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
        Gizmos.color = Color.white;
    }
}