using UnityEngine;

public class BordersCalculator
{
    public Vector2 ReturnRandomPositionWithinScreen()
    {
        if (Camera.main == null)
            throw new MissingComponentException();
        float zPosition = -Camera.main.transform.position.z;
        Vector2 lowestPoint = Camera.main.ViewportToWorldPoint(new Vector3(0,0,-zPosition));
        Vector2 highestPoint = Camera.main.ViewportToWorldPoint(new Vector3(1,1,-zPosition));
        float randomX = Random.Range(lowestPoint.x, highestPoint.x);
        float randomY = Random.Range(lowestPoint.y, highestPoint.y);
        return new Vector2(randomX, randomY);
    }
}