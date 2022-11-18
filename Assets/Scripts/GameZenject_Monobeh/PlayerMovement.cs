using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private void Update()
    {
        if (Camera.main == null)
            throw new MissingComponentException();
        Vector3 mousePosition = UnityEngine.Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}